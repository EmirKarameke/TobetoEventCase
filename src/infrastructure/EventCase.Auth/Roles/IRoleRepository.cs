using EventCase.Common.Repositories;

namespace EventCase.Auth.Roles
{
    public interface IRoleRepository<TKey> : IRepositoryBase<Role<TKey>, TKey>
        where TKey : struct
    {
    }
}
