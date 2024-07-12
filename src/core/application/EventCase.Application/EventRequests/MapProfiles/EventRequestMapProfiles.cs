using AutoMapper;
using EventCase.Domain.EventRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCase.Application.EventRequests.MapProfiles;

public class EventRequestMapProfiles: Profile
{
    public EventRequestMapProfiles() 
    {
        CreateMap<EventRequest, EventRequest>().ReverseMap();
    }
}
