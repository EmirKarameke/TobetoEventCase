using EventCase.Auth.Users;

namespace EventCase.Auth
{
    public interface IAuthService<TKey>
        where TKey : struct
    {
        Task<bool> Register(IUser<TKey> user, string password);
        Task<string> Login(string emailOrUserName, string password);

        Task<string> Logout();

    }
}
