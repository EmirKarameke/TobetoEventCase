using EventCase.Auth.Users;

namespace EventCase.EntityFrameworkCore.Users
{
    public class UserRoleRepository : RepositoryBase<UserRole<Guid>, Guid>, IUserRoleRepository<Guid>
    {
        public UserRoleRepository(EventCaseContext context) : base(context)
        {
        }
    }
}
