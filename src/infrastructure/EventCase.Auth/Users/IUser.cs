using EventCase.Common.Entities;

namespace EventCase.Auth.Users
{
    public interface IUser<TKey> : IEntity<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
        public string EmailOrUserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


        public ICollection<UserRole<TKey>> Roles { get; set; }
        public ICollection<UserPermission<TKey>> Permissions { get; set; }
    }
}
