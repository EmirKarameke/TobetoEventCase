using EventCase.Application.Contract.Employees.Dtos;
using EventCase.Domain.EventRequests.Enums;

namespace EventCase.Application.Contract.EventRequests.Dtos
{
    public class EventRequestDto
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public MemberDto Member { get; set; }
        public Guid EventId { get; set; }
        public RequestStatu RequestStatu { get; set; }
    }
}
