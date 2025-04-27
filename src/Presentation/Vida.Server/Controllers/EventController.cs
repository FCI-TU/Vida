using Microsoft.AspNetCore.Mvc;
using Vida.Application.Dtos.EventDtos;
using Vida.Application.Interfaces.Services;
using Vida.Server.Extensions;

namespace Vida.Server.Controllers;
public class EventController : BaseController
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<ActionResult> GetEvents()
    {
        var result = await _eventService.GetEventsAsync();

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetEventById(int id)
    {
        var result = await _eventService.GetEventByIdAsync(id);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("upcoming")]
    public async Task<ActionResult> GetUpcomingEvents()
    {
        var result = await _eventService.GetEventsAsync();

        if (!result.IsSuccess)
            return result.ToProblem();

        var today = DateTime.UtcNow.Date;
        var upcomingEvents = result.Value
            .Where(e => e.EventDate >= today && e.IsActive)
            .OrderBy(e => e.EventDate)
            .ThenBy(e => e.EventTime)
            .ToList();

        return Ok(upcomingEvents);
    }

    [HttpGet("category/{category}")]
    public async Task<ActionResult> GetEventsByCategory(string category)
    {
        var result = await _eventService.GetEventsAsync();

        if (!result.IsSuccess)
            return result.ToProblem();

        var categoryEvents = result.Value
            .Where(e => e.Category.ToLower() == category.ToLower() && e.IsActive)
            .OrderBy(e => e.EventDate)
            .ToList();

        return Ok(categoryEvents);
    }

    [HttpGet("{eventId:int}/registrations")]
    public async Task<ActionResult> GetEventRegistrations(int eventId)
    {
        var result = await _eventService.GetEventRegistrationsByEventIdAsync(eventId);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterForEvent(EventRegistrationRequest model)
    {
        var result = await _eventService.RegisterForEventAsync(model);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
}