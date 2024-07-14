using AutoMapper;
using EventCase.Application.Contract.EventRequests.Dtos;
using EventCase.Domain.EventRequests;

namespace EventCase.Application.EventRequests.MapProfiles;

public class EventRequestMapProfiles : Profile
{
    public EventRequestMapProfiles()
    {
        CreateMap<EventRequestDto, EventRequest>().ReverseMap();
    }
}
