using Blazored.LocalStorage;
using EventCase.Application.Contract.Employees.Dtos;
using EventCase.Blazor.Web.Providers;
using EventCase.Blazor.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text;
using System.Text.Json;

namespace EventCase.Blazor.Web.Pages;

public partial class LoginPage
{
    [Inject] IHttpService httpService { get; set; }
    [Inject] ILocalStorageService localStorageService { get; set; }
    [Inject] NavigationManager navigationManager { get; set; }
    [Inject] AuthenticationStateProvider authStateProvider { get; set; }
    public MemberLoginRequest user { get; set; } = new();
    private async Task Login()
    {
        ServiceRequestBase serviceRequestBase = new ServiceRequestBase();
        serviceRequestBase.Url = serviceRequestBase.Url + "Member/Login";
        var json = JsonSerializer.Serialize(user);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        serviceRequestBase.Object = content;
        var req = serviceRequestBase;
        var response = await httpService.PostAsync<string>(req);
        await localStorageService.SetItemAsStringAsync("token", response.Data);
        ((AuthStateProvider)authStateProvider).NotifyUserLogin(response.Data);
        navigationManager.NavigateTo("/");

    }
}
