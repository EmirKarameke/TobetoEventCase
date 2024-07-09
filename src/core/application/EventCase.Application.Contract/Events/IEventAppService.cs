using EventCase.Application.Contract.Events.Dtos;
using EventCase.Application.Contract.ServiceTypes;

namespace EventCase.Application.Contract.Events;

public interface IEventAppService
{
    Task<ServiceResponse<EventDto>> Create(EventDto member);
    Task<ServiceResponse<EventDto>> Update(EventDto member);
    Task<ServiceResponse<EventDto>> Delete(Guid Id);
    Task<ServiceResponse<EventDto>> GetList();
}
