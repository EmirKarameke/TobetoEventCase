namespace EventCase.Auth.Users
{
    //public abstract class User : IEntity<Guid>
    //{
    //    [Key]
    //    public Guid Id { get; set; }
    //    public string UserNameOrEmail { get; set; }
    //    public byte[] PasswordHash { get; set; }
    //    public byte[] PasswordSalt { get; set; }

    //    //public ICollection<UserRole> Roles { get; set; }
    //    //public ICollection<UserPermission> Permissions { get; set; }

    //    public void SetPassword(string password)
    //    {
    //        CreatePassword(password, out var passwordHash, out var passwordSalt);

    //        this.PasswordHash = passwordHash;
    //        this.PasswordSalt = passwordSalt;
    //    }

    //    private void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    //    {
    //        using (var hmac = new System.Security.Cryptography.HMACSHA512())
    //        {
    //            passwordSalt = hmac.Key;
    //            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    //        }
    //    }

    //    public bool VerifyPassword(string password)
    //    {
    //        using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
    //        {
    //            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    //            for (int i = 0; i < computedHash.Length; i++)
    //            {
    //                if (computedHash[i] != PasswordHash[i])
    //                {
    //                    return false;
    //                }
    //            }
    //        }
    //        return true;
    //    }
    //}
}
