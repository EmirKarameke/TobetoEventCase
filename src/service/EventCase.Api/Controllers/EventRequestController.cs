using AutoMapper;
using EventCase.Application.Contract.Events.Dtos;
using EventCase.Application.Contract.Events;
using EventCase.Application.Contract.ServiceTypes;
using EventCase.Domain.Events;
using Microsoft.AspNetCore.Mvc;
using EventCase.Application.Contract.EventRequests;
using EventCase.Application.Contract.EventRequests.Dtos;
using EventCase.Domain.EventRequests;

namespace EventCase.Api.Controllers;

[ApiController]
[Route("[controller]/[action]/")]
public class EventRequestController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEventRequestAppService _eventRequestAppService;
    public EventRequestController(IMapper mapper, IEventRequestAppService eventRequestAppService)
    {
        _mapper = mapper;
        _eventRequestAppService = eventRequestAppService;
    }

    [HttpPost]
    public async Task<ServiceResponse<EventRequestDto>> CreateEvent(EventRequestDto eventRequest)
    {
        try
        {
            var result = await _eventRequestAppService.Create(eventRequest);
            var response = new ServiceResponse<EventRequestDto>()
            {
                Success = true,
                Data = result.Data
            };
            return response;
        }
        catch (Exception ex)
        {
            var response = new ServiceResponse<EventRequestDto>()
            {
                Success = false,
                Message = ex.Message
            };
            return response;
        }
    }

    [HttpGet]

    public async Task<ServiceResponse<List<EventRequest>>> GetAllEvents()
    {
        try
        {
            var entities = await _eventRequestAppService.GetList();
            var response = new ServiceResponse<List<EventRequest>>()
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
    public async Task<ServiceResponse<EventRequestDto>> UpdateEvent(EventRequestDto eventRequest)
    {
        try
        {
            var entitiy = await _eventRequestAppService.Update(eventRequest);
            var response = new ServiceResponse<EventRequestDto>()
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
    public async Task<ServiceResponse<bool>> DeleteEvent([FromQuery] Guid Id)
    {
        try
        {
            return await _eventRequestAppService.Delete(Id);

        }
        catch (Exception ex)
        {
            throw;
        }

    }
}
