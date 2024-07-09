using AutoMapper;
using EventCase.Application.Contract.Events.Dtos;
using EventCase.Domain.Events;

namespace EventCase.Application.Events.MapProfiles;

public class EventMapProfile : Profile
{
    public EventMapProfile()
    {
        CreateMap<EventDto, Event>().ReverseMap();
    }
}
