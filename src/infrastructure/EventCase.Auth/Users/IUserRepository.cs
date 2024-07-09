using EventCase.Common.Repositories;

namespace EventCase.Auth.Users
{
    public interface IUserRepository<TKey> : IRepositoryBase<IUser<TKey>, TKey>
        where TKey : struct
    {
        Task<IUser<TKey>> GetEmployee(string userNameOrEmail);
    }
}
