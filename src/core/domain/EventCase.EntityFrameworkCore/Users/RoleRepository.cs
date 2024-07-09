using EventCase.Auth.Roles;

namespace EventCase.EntityFrameworkCore.Users
{
    public class RoleRepository : RepositoryBase<Role<Guid>, Guid>, IRoleRepository<Guid>
    {
        public RoleRepository(EventCaseContext context) : base(context)
        {
        }
    }
}
