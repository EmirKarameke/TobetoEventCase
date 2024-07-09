using AutoMapper;
using EventCase.Application.Contract.Events.Dtos;
using EventCase.Domain.Events;

namespace EventCase.Application.Events.MapProfiles;

public class EventMapProfiles : Profile
{
    public EventMapProfiles()
    {
        CreateMap<EventDto, Event>().ReverseMap();
    }
}
