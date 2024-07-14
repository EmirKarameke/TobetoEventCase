using EventCase.Domain.EventRequests.Enums;

namespace EventCase.Application.Contract.Events.Dtos
{
    public class EventTableItemDto
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; } = new DateOnly();
        public TimeOnly Time { get; set; } = new TimeOnly();
        public string Location { get; set; }

        public int TotalMemberNumber { get; set; }

        public bool IsRequestSend { get; set; }
        public RequestStatu? Status { get; set; }
    }
}
