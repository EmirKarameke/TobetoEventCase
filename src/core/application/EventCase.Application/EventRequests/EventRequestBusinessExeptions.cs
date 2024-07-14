using EventCase.Application.Contract.EventRequests.Dtos;
using EventCase.Common.Exeptions;
using EventCase.Domain.EventRequests;
using EventCase.Domain.Events;

namespace EventCase.Application.EventRequests;

public class EventRequestBusinessExeptions
{
    IEventRequestRepository eventRequestRepository;
    IEventRepository eventRepository;

    public EventRequestBusinessExeptions(IEventRequestRepository eventRequestRepository, IEventRepository eventRepository)
    {
        this.eventRequestRepository = eventRequestRepository;
        this.eventRepository = eventRepository;
    }

    public async Task CheckRequestTime(EventRequestDto eventRequestDto)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var Event = await eventRepository.SingleOrDefaultAsync(e => e.Id == eventRequestDto.EventId);
        if (DateTime.Parse(Event.Date.ToShortDateString()+" "+Event.Time.ToShortTimeString()) - DateTime.Now < TimeSpan.FromHours(24))
        {
            throw new BusinessException("24 Saat Kaldığı için katılma isteği gönderemezsiniz.. ");
        }
    }


}
