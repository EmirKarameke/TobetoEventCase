using AutoMapper;
using EventCase.Application.Contract.EventRequests;
using EventCase.Application.Contract.EventRequests.Dtos;
using EventCase.Application.Contract.ServiceTypes;
using EventCase.Domain.EventRequests;

namespace EventCase.Application.EventRequests;

public class EventRequestAppService : IEventRequestAppService
{
    IEventRequestRepository _eventRequestRepository;
    IMapper _mapper;
    EventRequestBusinessExeptions BusinessExeptions;
    public EventRequestAppService(IEventRequestRepository eventRequestRepository, IMapper mapper, EventRequestBusinessExeptions businessExeptions)
    {
        _eventRequestRepository = eventRequestRepository;
        _mapper = mapper;
        BusinessExeptions = businessExeptions;
    }
    public async Task<ServiceResponse<EventRequestDto>> Create(EventRequestDto eventRequest)
    {
        var result = new ServiceResponse<EventRequestDto>();
        BusinessExeptions.CheckRequestTime(eventRequest);
        var createdEvent = _mapper.Map<EventRequest>(eventRequest);
        try
        {
            var entity = await _eventRequestRepository.AddAsync(createdEvent);
            result.Success = true;
            result.Data = _mapper.Map<EventRequestDto>(entity);
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
            var entity = await _eventRequestRepository.SingleOrDefaultAsync(i => i.Id == Id);
            await _eventRequestRepository.RemoveAsync(entity);
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

    public async Task<ServiceResponse<List<EventRequestDto>>> GetList()
    {
        var result = new ServiceResponse<List<EventRequestDto>>();
        try
        {
            var eventList = await _eventRequestRepository.GetAllAsync();
            var events = _mapper.Map<List<EventRequestDto>>(eventList);
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
    public async Task<ServiceResponse<List<EventRequestDto>>> GetList(Guid id)
    {
        var result = new ServiceResponse<List<EventRequestDto>>();
        try
        {
            var eventList = await _eventRequestRepository.GetAllAsync();
            eventList = eventList.Where(i => i.MemberId == id);
            var events = _mapper.Map<List<EventRequestDto>>(eventList);
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

    public async Task<ServiceResponse<List<EventRequestDto>>> GetListById(Guid Id)
    {
        var result = new ServiceResponse<List<EventRequestDto>>();
        try
        {
            var requestList = await _eventRequestRepository.FindAsync(r => r.EventId == Id, i => i.Member);
            var requests = _mapper.Map<List<EventRequestDto>>(requestList);
            result.Success = true;
            result.Data = requests;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = ex.Message;
        }
        return result;
    }

    public async Task<ServiceResponse<EventRequestDto>> Update(EventRequestDto eventRequest)
    {
        var result = new ServiceResponse<EventRequestDto>();
        BusinessExeptions.CheckRequestTime(eventRequest);
        var oldEvent = await _eventRequestRepository.SingleOrDefaultAsync(e => e.Id == eventRequest.Id);
        var updatedEvent = _mapper.Map(eventRequest, oldEvent);
        try
        {
            var entity = await _eventRequestRepository.UpdateAsync(updatedEvent);
            result.Success = true;
            result.Data = _mapper.Map<EventRequestDto>(entity);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = ex.Message;
        }
        return result;
    }
}
