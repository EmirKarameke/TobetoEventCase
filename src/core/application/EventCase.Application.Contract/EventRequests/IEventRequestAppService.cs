using EventCase.Application.Contract.EventRequests.Dtos;
using EventCase.Application.Contract.Events.Dtos;
using EventCase.Application.Contract.ServiceTypes;
using EventCase.Domain.EventRequests;
using EventCase.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCase.Application.Contract.EventRequests
{
    public interface IEventRequestAppService
    {
        Task<ServiceResponse<EventRequestDto>> Create(EventRequestDto eventRequest);
        Task<ServiceResponse<EventRequestDto>> Update(EventRequestDto eventRequest);
        Task<ServiceResponse<bool>> Delete(Guid Id);
        Task<ServiceResponse<List<EventRequest>>> GetList();
    }
}
