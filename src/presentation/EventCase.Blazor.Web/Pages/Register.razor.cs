using Blazored.LocalStorage;
using EventCase.Application.Contract.Members.Dtos;
using EventCase.Blazor.Web.Providers;
using EventCase.Blazor.Web.Services;
using Microsoft.AspNetCore.Components;
using static EventCase.Blazor.Web.Pages.LoginPage;
using System.Text;
using System.Text.Json;

namespace EventCase.Blazor.Web.Pages
{
    public partial class Register
    {
        [Inject] IHttpService httpService { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }


        MemberRegisterDto member = new MemberRegisterDto();

        private async Task RegisterMember()
        {
            ServiceRequestBase serviceRequestBase = new ServiceRequestBase();
            serviceRequestBase.Url = serviceRequestBase.Url + "Member/Register";
            var json = JsonSerializer.Serialize(member);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceRequestBase.Object = content;
            var req = serviceRequestBase;
            var response = await httpService.PostAsync<string>(req);

            navigationManager.NavigateTo("/");

        }

    }
}
