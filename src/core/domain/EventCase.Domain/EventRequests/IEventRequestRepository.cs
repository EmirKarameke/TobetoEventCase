using EventCase.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCase.Domain.EventRequests;

public interface IEventRequestRepository : IRepositoryBase<EventRequest,Guid>
{
}
