using Vida.Application.Dtos.EventDtos;
using Vida.Domain.ErrorHandling;

namespace Vida.Application.Interfaces.Services;

public interface IEventService
{
    Task<Result<IReadOnlyList<EventResponse>>> GetEventsAsync();
    Task<Result<EventResponse>> GetEventByIdAsync(int id);
    Task<Result<IReadOnlyList<EventRegistrationResponse>>> GetEventRegistrationsByEventIdAsync(int eventId);
    Task<Result<EventRegistrationResponse>> RegisterForEventAsync(EventRegistrationRequest model);
}