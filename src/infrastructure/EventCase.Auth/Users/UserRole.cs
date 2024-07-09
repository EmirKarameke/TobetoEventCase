using EventCase.Auth.Roles;
using EventCase.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventCase.Auth.Users
{
    [Table("UserRoles")]
    public class UserRole<TKey> : IEntity<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
        public Role<TKey> Role { get; set; }
        public TKey RoleId { get; set; }

        public IUser<TKey> User { get; set; }
        public TKey UserId { get; set; }
    }
}
