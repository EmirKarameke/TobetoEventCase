using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using EventCase.Blazor.Web;
using EventCase.Blazor.Web.Providers;
using EventCase.Blazor.Web.Services;
using EventCase.Blazor.Web.Validators;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<ServiceRequestBase>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddAuthorizationCore();
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

builder.Services.AddBlazoredLocalStorage();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.ConfigureValidator();


await builder.Build().RunAsync();
