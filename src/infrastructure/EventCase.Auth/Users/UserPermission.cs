using EventCase.Auth.Permissions;
using EventCase.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCase.Auth.Users
{
    [Table("UserPermissions")]
    public class UserPermission<TKey> : IEntity<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
        public Permission<TKey> Permission { get; set; }
        public TKey PermissionId { get; set; }

        public IUser<TKey> User { get; set; }
        public TKey UserId { get; set; }
    }
}
