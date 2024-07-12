using AutoMapper;
using EventCase.Application.Contract.EventRequests;
using EventCase.Application.Contract.EventRequests.Dtos;
using EventCase.Application.Contract.Events.Dtos;
using EventCase.Application.Contract.ServiceTypes;
using EventCase.Domain.EventRequests;
using EventCase.Domain.EventRequests.Enums;
using EventCase.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCase.Application.EventRequests;

public class EventRequestAppService : IEventRequestAppService
{
    IEventRequestRepository _eventRequestRepository;
    IMapper _mapper;

    public EventRequestAppService(IEventRequestRepository eventRequestRepository, IMapper mapper)
    {
        _eventRequestRepository = eventRequestRepository;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<EventRequestDto>> Create(EventRequestDto eventRequest)
    {
        var result = new ServiceResponse<EventRequestDto>();
        result.Data.RequestStatu = RequestStatu.Pending;
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

    public async Task<ServiceResponse<List<EventRequest>>> GetList()
    {
        var result = new ServiceResponse<List<EventRequest>>();
        try
        {
            var eventList = await _eventRequestRepository.GetAllAsync();
            var events = _mapper.Map<List<EventRequest>>(eventList);
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

    public async Task<ServiceResponse<EventRequestDto>> Update(EventRequestDto eventRequest)
    {
        var result = new ServiceResponse<EventRequestDto>();
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
