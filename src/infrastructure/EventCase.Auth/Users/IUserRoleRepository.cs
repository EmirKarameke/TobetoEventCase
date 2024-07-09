using EventCase.Common.Repositories;

namespace EventCase.Auth.Users
{
    public interface IUserRoleRepository<TKey> : IRepositoryBase<UserRole<TKey>, TKey>
        where TKey : struct
    {
    }
}
