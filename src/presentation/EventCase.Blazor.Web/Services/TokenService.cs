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

    public async Task<JwtSecurityToken> ReadToken()
    {
        var token = await localStorageService.GetItemAsStringAsync("token");
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        return jwtToken;
    }
    public async Task<Guid> GetMemberId()
    {
        var readedToken = await ReadToken();
        if (readedToken != null)
        {
            var nameIdentifierClaim = readedToken.Claims
                .FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            if (nameIdentifierClaim == null || string.IsNullOrEmpty(nameIdentifierClaim.Value))
            {
                throw new InvalidOperationException("NameIdentifier claim is not found or is empty.");
            }
            else
            {
                return MemberId = Guid.Parse(nameIdentifierClaim.Value);
            }

        }
        else
        {
            throw new InvalidOperationException("NameIdentifier claim is not found or is empty.");
        }


    }
}
