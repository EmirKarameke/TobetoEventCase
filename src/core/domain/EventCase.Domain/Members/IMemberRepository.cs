using EventCase.Common.Repositories;

namespace EventCase.Domain.Employees;

public interface IMemberRepository : IRepositoryBase<Member, Guid>
{
}
