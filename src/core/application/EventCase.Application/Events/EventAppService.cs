using AutoMapper;
using EventCase.Application.Contract.Events;
using EventCase.Application.Contract.Events.Dtos;
using EventCase.Application.Contract.ServiceTypes;
using EventCase.Common.List;
using EventCase.Domain.Events;

namespace EventCase.Application.Events;

public class EventAppService : IEventAppService
{

    IEventRepository _eventRepository;
    IMapper _mapper;
    EventBusinessExeptions _eventBusinessExeptions;
    public EventAppService(IEventRepository eventRepository, IMapper mapper, EventBusinessExeptions eventBusinessExeptions)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _eventBusinessExeptions = eventBusinessExeptions;
    }

    public async Task<ServiceResponse<EventDto>> Create(EventDto Event)
    {
        var result = new ServiceResponse<EventDto>();
        _eventBusinessExeptions.CheckEventDate(Event);

        var createdEvent = _mapper.Map<Event>(Event);



        try
        {
            var entity = await _eventRepository.AddAsync(createdEvent);
            result.Success = true;
            result.Data = _mapper.Map<EventDto>(entity);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = ex.Message;
        }
        return result;
    }
    
    public async Task<ServiceResponse<bool>> Delete(Guid Id)
    {
        var result = new ServiceResponse<bool>();
        try
        {
            var entity = await _eventRepository.SingleOrDefaultAsync(i => i.Id == Id);
            await _eventRepository.RemoveAsync(entity);
            result.Success = true;
            result.Data = true;

        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = ex.Message;

        }
        return result;
    }

    public async Task<ServiceResponse<EventDto>> GetEvent(Guid Id)
    {
        var result = new ServiceResponse<EventDto>();
        try
        {
            var entity = await _eventRepository.SingleOrDefaultAsync(i => i.Id == Id);
            var Event = _mapper.Map<EventDto>(entity);

            result.Success = true;
            result.Data = Event;
        }
        catch (Exception ex) 
        {
            result.Success = false;
        }
        return result;
    }

    public async Task<ServiceResponse<List<Event>>> GetList()
    {
        var result = new ServiceResponse<List<Event>>();
        try
        {
            var eventList = await _eventRepository.GetAllAsync();
            var events = _mapper.Map<List<Event>>(eventList);
            result.Success = true;
            result.Data = events;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = ex.Message;
        }
        return result;
    }

    public async Task<ServiceResponse<PagedList<EventDto>>> GetPagedList(int pageNumber)
    {
        int pageSize = 10;
        var response = new ServiceResponse<PagedList<EventDto>>();
        var query = await _eventRepository.GetAllAsync();

        query = query.Where(i => i.Date > DateOnly.FromDateTime(DateTime.Now));
        var totalCount = query.Count();

        var displayResult = query.OrderBy(i => i.Date).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(i => _mapper.Map<EventDto>(i)).ToList();
        var list = new PagedList<EventDto>()
        {
            TotalRowCount = totalCount,
            DisplayedResult = displayResult
        };
        list.SetPageNumbers();

        response.Data = list;
        response.Success = true;
        return response;
    }

    public async Task<ServiceResponse<EventDto>> Update(EventDto Event)
    {
        var result = new ServiceResponse<EventDto>();
        _eventBusinessExeptions.CheckEventDate(Event);
        var oldEvent = await _eventRepository.SingleOrDefaultAsync(e => e.Id == Event.Id);
        var updatedEvent = _mapper.Map(Event, oldEvent);
        try
        {
            var entity = await _eventRepository.UpdateAsync(updatedEvent);
            result.Success = true;
            result.Data = _mapper.Map<EventDto>(entity);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = ex.Message;
        }
        return result;
    }
    
}