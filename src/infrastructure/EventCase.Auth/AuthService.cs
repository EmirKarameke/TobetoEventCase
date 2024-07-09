using EventCase.Auth.Permissions;
using EventCase.Auth.Roles.RolePermissions;
using EventCase.Auth.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventCase.Auth;

public class AuthService<TKey> : IAuthService<TKey>
    where TKey : struct
{

    IUserRepository<TKey> userRepository;
    IUserRoleRepository<TKey> userRoleRepository;
    IRolePermissionRepository<TKey> rolePermissionRepository;
    IUserPermissionRepository<TKey> userPermissionRepository;
    public AuthService(IUserRepository<TKey> userRepository,
        IUserRoleRepository<TKey> userRoleRepository,
        IRolePermissionRepository<TKey> rolePermissionRepository,
        IUserPermissionRepository<TKey> userPermissionRepository)
    {
        this.userRepository = userRepository;
        this.userRoleRepository = userRoleRepository;
        this.rolePermissionRepository = rolePermissionRepository;
        this.userPermissionRepository = userPermissionRepository;
    }



    public async Task<string> Login(string emailOrUserName, string password)
    {
        var user = await userRepository.GetEmployee(emailOrUserName);
        if (user == null) throw new Exception("Kullanıcı Adı Şifre Hatası");

        var passwordResult = VerifyPassword(password, user.PasswordSalt, user.PasswordHash);
        if (!passwordResult) throw new Exception("Kullanıcı Adı Şifre Hatası");

        var userRoles = await userRoleRepository.FindAsync(i => i.UserId.Equals(user.Id));
        var userRoleIds = userRoles.Select(i => i.RoleId).ToList();
        var rolePermissions = await rolePermissionRepository.FindAsync(i => userRoleIds.Contains(i.RoleId), i => i.Permission);

        var userPermissions = await userPermissionRepository.FindAsync(i => i.UserId.Equals(user.Id), i => i.Permission);

        var allPermissions = new List<Permission<TKey>>();
        allPermissions.AddRange(userPermissions.Select(i => i.Permission));
        allPermissions.AddRange(rolePermissions.Select(i => i.Permission));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fdsgerwt-rdgyerbn-oslks-rr-vfxzver-dsfasdf"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.Now.AddDays(7);

        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.EmailOrUserName),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
    };

        foreach (var permission in allPermissions)
        {
            claims.Add(new Claim(ClaimTypes.Role, permission.PermissionName));
        }

        var token = new JwtSecurityToken(
            "www.EventCase.com",
            "www.EventCase.com",
            expires: expiry,
            signingCredentials: creds,
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }

    public async Task<string> Logout()
    {
        return "";
    }

    private void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    public bool VerifyPassword(string password, byte[] passwordSalt, byte[] passwordHash)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public async Task<bool> Register(IUser<TKey> user,string password)
    {

        CreatePassword(password, out var passwordHash, out var passwordSalt);

        user.PasswordSalt = passwordSalt;
        user.PasswordHash = passwordHash;

        try
        {
            await userRepository.AddAsync(user);
        }
        catch (Exception e)
        {

            throw;
        }

        return true;
    }
}
