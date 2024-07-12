using EventCase.Domain.EventRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCase.EntityFrameworkCore.EventRequests
{
    public class EventRequestRepository : RepositoryBase<EventRequest, Guid>, IEventRequestRepository
    {
        public EventRequestRepository(EventCaseContext context) : base(context)
        {
        }
    }
}
