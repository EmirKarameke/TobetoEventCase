using EventCase.Common.Entities;
using EventCase.Domain.Employees;

namespace EventCase.Domain.Events;

public class Event : IEntity<Guid>
{
    public Member Memeber { get; set; }
    public Guid MemberId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public TimeOnly Time { get; set; }
    public string Location { get; set; }

}
