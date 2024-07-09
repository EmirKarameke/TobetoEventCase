using EventCase.Auth.Users;
using EventCase.Common.Entities;
using EventCase.Domain.Events;

namespace EventCase.Domain.Employees;

public class Member : IUser<Guid>, IEntity<Guid>
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string EmailOrUserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public ICollection<UserRole<Guid>> Roles { get; set; }
    public ICollection<UserPermission<Guid>> Permissions { get; set; }
    public ICollection<Event>? Events { get; set; }
}
