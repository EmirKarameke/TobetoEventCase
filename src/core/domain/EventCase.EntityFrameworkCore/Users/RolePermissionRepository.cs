using EventCase.Auth.Roles.RolePermissions;

namespace EventCase.EntityFrameworkCore.Users
{
    public class RolePermissionRepository : RepositoryBase<RolePermission<Guid>, Guid>, IRolePermissionRepository<Guid>
    {
        public RolePermissionRepository(EventCaseContext context) : base(context)
        {
        }
    }
}
