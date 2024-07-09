using EventCase.Common.Repositories;

namespace EventCase.Auth.Roles.RolePermissions;

public interface IRolePermissionRepository<TKey> : IRepositoryBase<RolePermission<TKey>, TKey>
        where TKey : struct
{
}
