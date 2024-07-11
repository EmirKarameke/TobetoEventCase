using AutoMapper;
using EventCase.Application.Contract.Events;
using EventCase.Application.Contract.Events.Dtos;
using EventCase.Application.Contract.ServiceTypes;
using EventCase.Domain.Events;
using Microsoft.AspNetCore.Mvc;

namespace EventCase.Api.Controllers;

[ApiController]
[Route("[controller]/[action]/")]
public class EventController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEventAppService _eventAppService;
    public EventController(IMapper mapper, IEventAppService eventAppService)
    {
        _mapper = mapper;
        _eventAppService = eventAppService;
    }

    [HttpPost]
    public async Task<ServiceResponse<EventDto>> CreateEvent(EventDto Event)
    {
        try
        {
            var result = await _eventAppService.Create(Event);
            var response = new ServiceResponse<EventDto>()
            {
                Success = true,
                Data = result.Data
            };
            return response;
        }
        catch (Exception ex)
        {
            var response = new ServiceResponse<EventDto>()
            {
                Success = false,
                Message = ex.Message
            };
            return response;
        }
    }

    [HttpGet]

    public async Task<ServiceResponse<List<Event>>> GetAllEvents()
    {
        try
        {
            var entities = await _eventAppService.GetList();
            var response = new ServiceResponse<List<Event>>()
            {
                Success = true,
                Data = entities.Data
            };
            return response;
        }
        catch (Exception ex)
        {
            throw;
        }


    }
    [HttpPut]
    public async Task<ServiceResponse<EventDto>> UpdateEvent(EventDto Event)
    {
        try
        {
            var entitiy = await _eventAppService.Update(Event);
            var response = new ServiceResponse<EventDto>()
            {
                Success = true,
                Data = entitiy.Data
            };
            return response;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    [HttpDelete]

    public async Task<ServiceResponse<bool>> DeleteEvent(Guid Id)
    {
        try
        {
            return await _eventAppService.Delete(Id);
        }
        catch (Exception ex)
        {
            throw;
        }

    }
}
