using EventCase.Common.Entities;
using EventCase.Domain.Employees;

namespace EventCase.Domain.Events;

public class Event : IEntity<Guid>
{
    public Member Member { get; set; }
    public Guid MemberId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string Location { get; set; }

}
