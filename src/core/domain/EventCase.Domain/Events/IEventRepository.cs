using EventCase.Common.Repositories;

namespace EventCase.Domain.Events;

public interface IEventRepository : IRepositoryBase<Event, Guid>
{
}
