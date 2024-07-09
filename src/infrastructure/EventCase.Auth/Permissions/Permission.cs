
using EventCase.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCase.Auth.Permissions
{
    [Table("Permissions")]
    public class Permission<Tkey> : IEntity<Tkey>
        where Tkey : struct
    {
        public Tkey Id { get; set; }
        public string PermissionName { get; set; }
        public string GroupAdi { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public PermissionTypes PermissionType { get; set; }
    }
}
