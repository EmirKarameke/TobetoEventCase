using EventCase.Auth.Permissions;

namespace EventCase.EntityFrameworkCore.Users
{
    public class PermissionRepository : RepositoryBase<Permission<Guid>, Guid>, IPermissionRepository<Guid>

    {
        public PermissionRepository(EventCaseContext context) : base(context)
        {
        }
    }
}
