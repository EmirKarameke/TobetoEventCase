using EventCase.Auth.Permissions;
using EventCase.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCase.Auth.Roles.RolePermissions
{
    [Table("RolePermissions")]
    public class RolePermission<Tkey> : IEntity<Tkey>
        where Tkey : struct
    {
        public Tkey Id { get; set; }

        public Role<Tkey> Role { get; set; }
        public Tkey RoleId { get; set; }

        public Permission<Tkey> Permission { get; set; }
        public Tkey PermissionId { get; set; }
    }
}
