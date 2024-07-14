using EventCase.Domain.EventRequests;

namespace EventCase.EntityFrameworkCore.EventRequests
{
    public class EventRequestRepository : RepositoryBase<EventRequest, Guid>, IEventRequestRepository
    {
        public EventRequestRepository(EventCaseContext context) : base(context)
        {
        }
    }
}
