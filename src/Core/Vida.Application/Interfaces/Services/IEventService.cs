using Vida.Application.Dtos.EventDtos;
using Vida.Domain.ErrorHandling;

namespace Vida.Application.Interfaces.Services
{
    public interface IEventService
    {
        Task<Result<IReadOnlyList<EventResponse>>> GetAllEventsAsync();
        Task<Result<EventResponse>> GetEventByIdAsync(int id);
        Task<Result<EventRegistrationResponse>> RegisterForEventAsync(EventRegistrationRequest request);
        Task<Result<IReadOnlyList<EventRegistrationResponse>>> GetEventRegistrationsAsync(int eventId);
        
    }
}
