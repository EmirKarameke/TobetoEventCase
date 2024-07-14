using EventCase.Common.Entities;
using EventCase.Domain.Employees;
using EventCase.Domain.EventRequests.Enums;
using EventCase.Domain.Events;

namespace EventCase.Domain.EventRequests;

public class EventRequest : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Event Event { get; set; }
    public Guid MemberId { get; set; }
    public Member Member  { get; set; }
    public RequestStatu RequestStatu { get; set; }
}
