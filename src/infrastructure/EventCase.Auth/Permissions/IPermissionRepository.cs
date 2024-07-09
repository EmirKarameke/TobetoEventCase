using EventCase.Common.Repositories;

namespace EventCase.Auth.Permissions;

public interface IPermissionRepository<TKey> : IRepositoryBase<Permission<TKey>, TKey>
    where TKey : struct
{
}
