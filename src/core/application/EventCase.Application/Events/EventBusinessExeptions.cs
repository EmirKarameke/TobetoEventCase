using EventCase.Application.Contract.Events.Dtos;
using EventCase.Common.Exeptions;
using EventCase.Domain.Events;

namespace EventCase.Application.Events;

public class EventBusinessExeptions
{
    IEventRepository _eventRepository;

    public EventBusinessExeptions(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public void CheckEventDate(EventDto eventDto)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        if (today > eventDto.Date)
        {
            throw new BusinessException("Geçmişe Etkinlik Oluşturamazsınız..");
        }
    }




}
