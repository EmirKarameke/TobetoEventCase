using EventCase.Application.Contract.EventRequests.Dtos;
using EventCase.Application.Contract.Events.Dtos;
using EventCase.Blazor.Web.Services;
using EventCase.Common.List;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Text.Json;

namespace EventCase.Blazor.Web.Pages
{
    public partial class Home
    {
        [Inject] IHttpService httpService { get; set; }
        [Inject] TokenService TokenService { get; set; }
        public PagedList<EventTableItemDto> EventList { get; set; }
        // public int CurrentPage { get; set; } = 1;
        public EventRequestDto EventRequest { get; set; }
        public List<EventRequestDto> EventRequestList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EventRequest = new EventRequestDto();
            EventList = new PagedList<EventTableItemDto>();
            EventRequestList = new List<EventRequestDto>();
            await CheckRequest();
            await GetPaginatedEventsList();
        }
        public async Task GetPaginatedEventsList()
        {
            var request = new ServiceRequestBase();
            request.Url = request.Url + $"Event/GetEventList?page={EventList.CurrentPage}";
            var response = await httpService.GetListAsync<PagedList<EventDto>>(request);
            var memberId = await TokenService.GetMemberId();
            EventList = new PagedList<EventTableItemDto>()
            {
                CurrentPage = EventList.CurrentPage,
                DisplayedPageNumbers = response.Data.DisplayedPageNumbers,
                DisplayedResult = response.Data.DisplayedResult.Select(i => new EventTableItemDto()
                {
                    Date = i.Date,
                    Id = i.Id,
                    IsRequestSend = EventRequestList.Any(e => e.EventId == i.Id && e.MemberId == memberId),
                    Location = i.Location,
                    MemberId = i.MemberId,
                    Name = i.Name,
                    Time = i.Time,
                    TotalMemberNumber = 0,
                    Status = EventRequestList.FirstOrDefault(e => e.EventId == i.Id && e.MemberId == memberId)?.RequestStatu
                }).ToList(),
                DisplayPerPage = response.Data.DisplayPerPage,
                DisplayRowCounts = response.Data.DisplayRowCounts,
                TotalPageCount = response.Data.TotalPageCount,
                TotalRowCount = response.Data.TotalRowCount
            };
        }
        bool toastVisible = false;
        public async Task JoinRequest(Guid eventId)
        {
            var request = new ServiceRequestBase();
            EventRequest.MemberId = await TokenService.GetMemberId();
            EventRequest.EventId = eventId;
            EventRequest.RequestStatu = Domain.EventRequests.Enums.RequestStatu.Beklemede;
            var json = JsonSerializer.Serialize(EventRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Object = content;
            request.Url = request.Url + "EventRequest/CreateEventRequest";
            var response = await httpService.PostAsync<EventRequestDto>(request);
            if (response.Success == true)
            {

                await OnInitializedAsync();
                toastVisible = true;
                StateHasChanged();
            }
        }
        public async Task CheckRequest()
        {
            var memberId = await TokenService.GetMemberId();
            ServiceRequestBase serviceRequestBase = new ServiceRequestBase();
            serviceRequestBase.Url = serviceRequestBase.Url + $"EventRequest/GetAllEventRequestsByMemberId/{memberId}";
            var result = await httpService.GetListAsync<List<EventRequestDto>?>(serviceRequestBase);
            if (result.Success)
            {
                EventRequestList = result.Data;
            }

        }



        private const string PREVIOUS = "previous";
        private const string NEXT = "next";



        private async Task Previous()
        {
            if (EventList.CurrentPage != 0)
            {
                EventList.CurrentPage--;
                await GoToPage(EventList.CurrentPage);
            }
        }

        private async Task Next()
        {
            if (EventList.DisplayedPageNumbers.Max() != EventList.CurrentPage)
            {
                EventList.CurrentPage++;
                await GoToPage(EventList.CurrentPage);
            }
        }

        private async Task GoToPage(int pageNumber)
        {
            EventList.CurrentPage = pageNumber;

            await CheckRequest();
            await GetPaginatedEventsList();
            StateHasChanged();
        }
    }
}
