using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EventCase.Blazor.Web.Providers
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        ILocalStorageService localStorageService;
        AuthenticationState anonymous;
        NavigationManager navigationManager;
        public AuthStateProvider(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
            anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await localStorageService.GetItemAsStringAsync("token");
            if (string.IsNullOrEmpty(token)) return anonymous;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var claims = new List<Claim>();
            claims.AddRange(jwtToken.Claims);

            var userIdentity = new ClaimsIdentity(claims, "jwtAuthType");
            var principal = new ClaimsPrincipal(userIdentity);

            return new AuthenticationState(principal);
        }

        public void NotifyUserLogin(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var claims = new List<Claim>();
            claims.AddRange(jwtToken.Claims);

            var identity = new ClaimsIdentity(claims, "jwtAuthType");
            var principal = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(principal);

            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public void NotifyUserLogout()
        {
            var identity = new ClaimsIdentity(); // No authentication type passed
            var principal = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(principal);

            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task<bool> IsAuthentication()
        {
            var state = await GetAuthenticationStateAsync();
            return state.User.Identity.IsAuthenticated;
        }
        public async Task Logout()
        {
            await localStorageService.RemoveItemAsync("token");
            NotifyUserLogout();
            navigationManager.NavigateTo("/login");
        }
    }
}
