using EventCase.Application.Contract.EventRequests.Dtos;
using EventCase.Application.Contract.Events.Dtos;
using EventCase.Blazor.Web.Services;
using EventCase.Common.List;
using EventCase.Domain.Employees;
using EventCase.Domain.EventRequests;
using EventCase.Domain.EventRequests.Enums;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Text.Json;

namespace EventCase.Blazor.Web.Pages;

public partial class EventDetailPage
{
    [Inject] IHttpService http { get; set; }
    [Parameter] public string? EventId { get; set; }

    public EventDto Event { get; set; }
    public EventRequestDto UpdatedRequest { get; set; }
    public PagedList<EventRequestWithMemberDto> EventRequest { get; set; }
    protected override async void OnInitialized()
    {
        
        EventRequest = new PagedList<EventRequestWithMemberDto>();
        UpdatedRequest = new EventRequestDto();
        Event = new EventDto();
        await GetEvent();
        await GetEventRequests();
    }

    public async Task GetEventRequests()
    {
        ServiceRequestBase serviceRequestBase = new ServiceRequestBase();
        serviceRequestBase.Url = serviceRequestBase.Url + $"EventRequest/GetListByEventId?Id={EventId}&pageNumber={EventRequest.CurrentPage}";
        var result = await http.GetListAsync<PagedList<EventRequestWithMemberDto>>(serviceRequestBase);
        EventRequest = new PagedList<EventRequestWithMemberDto> 
        {
            CurrentPage = EventRequest.CurrentPage,
            DisplayedPageNumbers = result.Data.DisplayedPageNumbers,
            DisplayedResult = result.Data.DisplayedResult,
            DisplayPerPage = result.Data.DisplayPerPage,
            DisplayRowCounts = result.Data.DisplayRowCounts,
            TotalPageCount = result.Data.TotalPageCount,
            TotalRowCount = result.Data.TotalRowCount
        };
        StateHasChanged();
    }
    public async Task GetEvent()
    {
        ServiceRequestBase serviceRequestBase = new ServiceRequestBase();
        serviceRequestBase.Url = serviceRequestBase.Url + $"Event/GetEventById?Id={EventId}";
        var result = await http.GetAsync<EventDto>(serviceRequestBase);
        if (result.Success)
        {
            Event = result.Data;
            StateHasChanged();
        }
    }

    public async Task AproveRequest(Guid Id)
    {
        ServiceRequestBase serviceRequestBase = new ServiceRequestBase();
        serviceRequestBase.Url = serviceRequestBase.Url + "EventRequest/UpdateEventRequest";
        var updatedRequest= EventRequest.DisplayedResult.Find(i=>i.Id == Id);
        updatedRequest.RequestStatu= Domain.EventRequests.Enums.RequestStatu.KabulEdildi;
        var json = JsonSerializer.Serialize(updatedRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        serviceRequestBase.Object = content;
        var result = await http.PutAsync<EventRequestDto>(serviceRequestBase);
        if (result.Success)
        {
            //EventRequest.Remove(EventRequest.Find(i=>i.Id==updatedRequest.Id));
            StateHasChanged();
        }
    }
    public async Task RejectRequest(Guid Id)
    {
        ServiceRequestBase serviceRequestBase = new ServiceRequestBase();
        serviceRequestBase.Url = serviceRequestBase.Url + "EventRequest/UpdateEventRequest";
        var updatedRequest = EventRequest.DisplayedResult.Find(i => i.Id == Id);
        updatedRequest.RequestStatu = Domain.EventRequests.Enums.RequestStatu.Reddedildi;
        var json = JsonSerializer.Serialize(updatedRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        serviceRequestBase.Object = content;
        var result = await http.PutAsync<EventRequestDto>(serviceRequestBase);
        if (result.Success)
        {
            StateHasChanged();
        }
    }









    private const string PREVIOUS = "previous";
    private const string NEXT = "next";



    private async Task Previous()
    {
        if (EventRequest.CurrentPage != 0)
        {
            EventRequest.CurrentPage--;
            await GoToPage(EventRequest.CurrentPage);
        }
    }

    private async Task Next()
    {
        if (EventRequest.DisplayedPageNumbers.Max() != EventRequest.CurrentPage)
        {
            EventRequest.CurrentPage++;
            await GoToPage(EventRequest.CurrentPage);
        }
    }

    private async Task GoToPage(int pageNumber)
    {
        EventRequest.CurrentPage = pageNumber;

        await GetEventRequests();
        StateHasChanged();
    }
}
