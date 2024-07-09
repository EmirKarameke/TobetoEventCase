using EventCase.Domain.Employees;

namespace EventCase.EntityFrameworkCore.Employees
{
    public class MemberRepository : RepositoryBase<Member, Guid>, IMemberRepository
    {
        public MemberRepository(EventCaseContext context) : base(context)
        {

        }
    }
}
