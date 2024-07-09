using EventCase.Auth.Users;
using Microsoft.EntityFrameworkCore;

namespace EventCase.EntityFrameworkCore.Users
{
    public class UserRepository : RepositoryBase<IUser<Guid>, Guid>, IUserRepository<Guid>
    {
        EventCaseContext context;
        public UserRepository(EventCaseContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IUser<Guid>> GetEmployee(string userNameOrEmail)
        {
            return await context.Members.FirstOrDefaultAsync(i => i.EmailOrUserName == userNameOrEmail);
        }
    }
}
