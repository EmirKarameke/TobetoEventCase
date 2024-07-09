﻿using AutoMapper;
using EventCase.Application.Contract.Events;
using EventCase.Application.Contract.Events.Dtos;
using EventCase.Application.Contract.ServiceTypes;
using EventCase.Domain.Events;

namespace EventCase.Application.Events;

public class EventAppService : IEventAppService
{

    IEventRepository _eventRepository;
    IMapper _mapper;

    public EventAppService(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<EventDto>> Create(EventDto Event)
    {
        var result = new ServiceResponse<EventDto>();
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
            var entity = await _eventRepository.FindAsync(i => i.Id == Id);
            var removedEntity = _mapper.Map<Event>(entity);
            await _eventRepository.RemoveAsync(removedEntity);
            result.Success = true;

        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = ex.Message;

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


    public Task<ServiceResponse<EventDto>> Update(EventDto Event)
    {
        throw new NotImplementedException();
    }
}