using EventCase.Common.Repositories;

namespace EventCase.Domain.EventRequests;

public interface IEventRequestRepository : IRepositoryBase<EventRequest, Guid>
{
}
