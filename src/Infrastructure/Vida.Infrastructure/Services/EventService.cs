using AutoMapper;
using Vida.Application.Dtos.EventDtos;
using Vida.Application.Interfaces.Repositories;
using Vida.Application.Interfaces.Services;
using Vida.Domain.ErrorHandling;

namespace Vida.Infrastructure.Services
{
    public class EventService(IUnitOfWork unitOfWork, IMapper mapper) : IEventService
    {
        public Task<Result<IReadOnlyList<EventResponse>>> GetAllEventsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Result<EventResponse>> GetEventByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Result<EventRegistrationResponse>> RegisterForEventAsync(EventRegistrationRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<Result<IReadOnlyList<EventRegistrationResponse>>> GetEventRegistrationsAsync(int eventId)
        {
            throw new NotImplementedException();
        }
    }
    
    
}
