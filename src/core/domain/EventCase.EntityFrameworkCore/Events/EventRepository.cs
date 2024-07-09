using EventCase.Domain.Events;

namespace EventCase.EntityFrameworkCore.Events
{
    public class EventRepository : RepositoryBase<Event, Guid>, IEventRepository
    {
        public EventRepository(EventCaseContext context) : base(context)
        {
        }
    }
}
