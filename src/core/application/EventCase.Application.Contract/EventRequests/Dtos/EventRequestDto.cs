using EventCase.Domain.EventRequests.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCase.Application.Contract.EventRequests.Dtos
{
    public class EventRequestDto
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public Guid EventId { get; set; }
        public RequestStatu RequestStatu { get; set; }
    }
}
