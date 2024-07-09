using EventCase.Common.Repositories;

namespace EventCase.Auth.Users
{
    public interface IUserPermissionRepository<TKey> : IRepositoryBase<UserPermission<TKey>, TKey>
        where TKey : struct
    {
    }
}
