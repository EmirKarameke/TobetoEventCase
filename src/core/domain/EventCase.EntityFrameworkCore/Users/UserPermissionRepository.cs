using EventCase.Auth.Users;

namespace EventCase.EntityFrameworkCore.Users
{
    public class UserPermissionRepository : RepositoryBase<UserPermission<Guid>, Guid>, IUserPermissionRepository<Guid>
    {
        public UserPermissionRepository(EventCaseContext context) : base(context)
        {
        }
    }
}
