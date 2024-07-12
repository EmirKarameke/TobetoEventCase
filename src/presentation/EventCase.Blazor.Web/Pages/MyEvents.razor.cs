using EventCase.Application.Contract.Events.Dtos;
using EventCase.Blazor.Web.Providers;
using EventCase.Blazor.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text;
using System.Text.Json;

namespace EventCase.Blazor.Web.Pages;

public partial class MyEvents
{
    [Inject] IHttpService httpService { get; set; }
    [Inject] AuthenticationStateProvider AuthProvider { get; set; }
    public EventDto EventDto { get; set; }
    public List<EventDto> ListEvents { get; set; }
    public EventDto SelectedEvent {  get; set; }
    protected override async void OnInitialized()
    {
        SelectedEvent = new EventDto();
        EventDto = new EventDto();
        ListEvents = new List<EventDto>();
        await GetEventList();
        TokenStuf();
    }
    public async Task AddEvent()
    {
        ServiceRequestBase serviceRequestBase = new ServiceRequestBase();
        serviceRequestBase.Url = serviceRequestBase.Url + "Event/CreateEvent";
        EventDto.MemberId = MemberId;
        var json = JsonSerializer.Serialize(EventDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        serviceRequestBase.Object = content;
        var result = await httpService.PostAsync<EventDto>(serviceRequestBase);
        if (result.Success)
        {
            await GetEventList();

        }
    }

    public async Task DeleteEvent(Guid Id)
    {
        ServiceRequestBase serviceRequestBase = new ServiceRequestBase();
        serviceRequestBase.Url = serviceRequestBase.Url + "Event/DeleteEvent?Id="+Id;
        var result = await httpService.DeleteAsync<bool>(serviceRequestBase);
        if (result.Success)
        {
            await GetEventList();

        }
    }
    public async Task UpdateEvent()
    {
        ServiceRequestBase serviceRequestBase = new ServiceRequestBase();
        serviceRequestBase.Url = serviceRequestBase.Url + "Event/UpdateEvent";
        SelectedEvent.MemberId = MemberId;
        var json = JsonSerializer.Serialize(SelectedEvent);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        serviceRequestBase.Object = content;
        var result = await httpService.PutAsync<EventDto>(serviceRequestBase);
        if (result.Success)
        {
            await GetEventList();

        }
    }
    public async Task GetEventList()
    {
        ServiceRequestBase serviceRequestBase = new ServiceRequestBase();
        serviceRequestBase.Url = serviceRequestBase.Url + "Event/GetAllEvents";
        var result = await httpService.GetListAsync<List<EventDto>>(serviceRequestBase);
        if (result.Success)
        {
            ListEvents = result.Data;
        }
        StateHasChanged();
    }
    public Guid MemberId { get; set; }
    public async void TokenStuf()
    {
        var readedToken = await ((AuthStateProvider)AuthProvider).ReadToken();
        var nameIdentifierClaim = readedToken.Claims
                    .FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
       MemberId= Guid.Parse(nameIdentifierClaim);
    }
}
