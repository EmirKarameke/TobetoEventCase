using EventCase.Application.Contract.EventRequests.Dtos;
using EventCase.Application.Contract.ServiceTypes;
using EventCase.Common.List;

namespace EventCase.Application.Contract.EventRequests
{
    public interface IEventRequestAppService
    {
        Task<ServiceResponse<EventRequestDto>> Create(EventRequestDto eventRequest);
        Task<ServiceResponse<EventRequestDto>> Update(EventRequestDto eventRequest);
        Task<ServiceResponse<bool>> Delete(Guid Id);
        Task<ServiceResponse<List<EventRequestDto>>> GetList(Guid id);
        Task<ServiceResponse<List<EventRequestDto>>> GetList();
        Task<ServiceResponse<PagedList<EventRequestWithMemberDto>>> GetListById(Guid Id, int pageNumber);
    }
}
