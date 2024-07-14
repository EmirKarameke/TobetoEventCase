using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace EventCase.Blazor.Web.Services;

public class TokenService
{
    [Inject] AuthenticationStateProvider AuthProvider { get; set; }
    public Guid MemberId { get; set; }
    ILocalStorageService localStorageService;

    public TokenService(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    public async Task<bool> IsTokenExist()
    {
        var token = await localStorageService.GetItemAsStringAsync("token");
        if (token == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public async Task<JwtSecurityToken> ReadToken()
    {
        var token = await localStorageService.GetItemAsStringAsync("token");

        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentNullException(nameof(token), "Token cannot be null or empty.");
        }

        var handler = new JwtSecurityTokenHandler();
        return handler.ReadJwtToken(token);
    }

    public async Task<Guid> GetMemberId()
    {
        var readedToken = await ReadToken();

        var nameIdentifierClaim = readedToken.Claims
            .FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

        if (nameIdentifierClaim == null || string.IsNullOrEmpty(nameIdentifierClaim.Value))
        {
            throw new InvalidOperationException("NameIdentifier claim is not found or is empty.");
        }

        return MemberId = Guid.Parse(nameIdentifierClaim.Value);
    }
}
