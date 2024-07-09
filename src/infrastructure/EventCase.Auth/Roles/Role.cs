
using EventCase.Auth.Roles.RolePermissions;
using EventCase.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCase.Auth.Roles
{
    [Table("Roles")]
    public class Role<TKey> : IEntity<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public RoleTypes RoleType { get; set; }

        public ICollection<RolePermission<TKey>> RolePermissions { get; set; }
    }
}
