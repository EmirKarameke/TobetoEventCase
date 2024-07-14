using EventCase.Application.Contract.Events.Dtos;
using EventCase.Application.Contract.ServiceTypes;
using EventCase.Common.List;
using EventCase.Domain.Events;

namespace EventCase.Application.Contract.Events;

public interface IEventAppService
{
    Task<ServiceResponse<EventDto>> Create(EventDto Event);
    Task<ServiceResponse<EventDto>> Update(EventDto Event);
    Task<ServiceResponse<bool>> Delete(Guid Id);
    Task<ServiceResponse<List<Event>>> GetList();//dto dönecek

    Task<ServiceResponse<PagedList<EventDto>>> GetPagedList(int pageNumber);
}
