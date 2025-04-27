using AutoMapper;
using Vida.Application.Dtos.EventDtos;
using Vida.Application.Interfaces.Repositories;
using Vida.Application.Interfaces.Services;
using Vida.Application.Specifications;
using Vida.Domain.Entities.EventEntities;
using Vida.Domain.ErrorHandling;

namespace Vida.Infrastructure.Services;
public class EventService : IEventService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EventService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IReadOnlyList<EventResponse>>> GetEventsAsync()
    {
        var events = await _unitOfWork.Repository<Event>().GetAllAsync();

        var eventResponses = new List<EventResponse>();

        foreach (var evt in events)
        {
            var eventResponse = _mapper.Map<Event, EventResponse>(evt);

            var spec = new BaseSpecifications<EventRegistration>
            {
                WhereCriteria = r => r.EventId == evt.Id
            };

            var registrations = await _unitOfWork.Repository<EventRegistration>().GetAllAsync(spec);

            int totalPeople = registrations.Sum(r => r.NumberOfPeople);

            eventResponse.TotalRegistrations = registrations.Count;
            eventResponse.AvailableSpots = Math.Max(0, evt.Capacity - totalPeople);

            eventResponses.Add(eventResponse);
        }

        return Result.Success<IReadOnlyList<EventResponse>>(eventResponses);
    }

    public async Task<Result<EventResponse>> GetEventByIdAsync(int id)
    {
        var evt = await _unitOfWork.Repository<Event>().GetEntityAsync(id);

        if (evt == null)
            return Result.Failure<EventResponse>(new Error(404, $"Event with id {id} not found"));

        var eventResponse = _mapper.Map<Event, EventResponse>(evt);

        var spec = new BaseSpecifications<EventRegistration>
        {
            WhereCriteria = r => r.EventId == evt.Id
        };

        var registrations = await _unitOfWork.Repository<EventRegistration>().GetAllAsync(spec);

        int totalPeople = registrations.Sum(r => r.NumberOfPeople);

        eventResponse.TotalRegistrations = registrations.Count;
        eventResponse.AvailableSpots = Math.Max(0, evt.Capacity - totalPeople);

        return Result.Success(eventResponse);
    }

    public async Task<Result<IReadOnlyList<EventRegistrationResponse>>> GetEventRegistrationsByEventIdAsync(int eventId)
    {
        var spec = new BaseSpecifications<EventRegistration>
        {
            WhereCriteria = r => r.EventId == eventId,
            IncludesCriteria = [r => r.Event]
        };

        var registrations = await _unitOfWork.Repository<EventRegistration>().GetAllAsync(spec);

        var registrationResponses = registrations.Select(r =>
            new EventRegistrationResponse
            {
                Id = r.Id,
                EventId = r.EventId,
                EventTitle = r.Event.Title,
                AppUserId = r.AppUserId,
                FullName = r.FullName,
                Email = r.Email,
                PhoneNumber = r.PhoneNumber,
                NumberOfPeople = r.NumberOfPeople,
                Notes = r.Notes,
                RegistrationDate = r.RegistrationDate,
                HasAttended = r.HasAttended
            }).ToList();

        return Result.Success<IReadOnlyList<EventRegistrationResponse>>(registrationResponses);
    }

    public async Task<Result<EventRegistrationResponse>> RegisterForEventAsync(EventRegistrationRequest model)
    {
        var evt = await _unitOfWork.Repository<Event>().GetEntityAsync(model.EventId);

        if (evt == null)
            return Result.Failure<EventRegistrationResponse>(new Error(404, $"Event with id {model.EventId} not found"));

        var spec = new BaseSpecifications<EventRegistration>
        {
            WhereCriteria = r => r.EventId == model.EventId && r.Email == model.Email
        };

        var existingRegistrations = await _unitOfWork.Repository<EventRegistration>().GetAllAsync(spec);

        if (existingRegistrations.Any())
            return Result.Failure<EventRegistrationResponse>(new Error(400, "This email is already registered for this event"));

        var capacitySpec = new BaseSpecifications<EventRegistration>
        {
            WhereCriteria = r => r.EventId == model.EventId
        };

        var allRegistrations = await _unitOfWork.Repository<EventRegistration>().GetAllAsync(capacitySpec);

        int totalPeople = allRegistrations.Sum(r => r.NumberOfPeople);

        if (totalPeople + model.NumberOfPeople > evt.Capacity)
            return Result.Failure<EventRegistrationResponse>(new Error(400, $"Not enough capacity. Only {evt.Capacity - totalPeople} spots left."));

        var registration = new EventRegistration
        {
            EventId = model.EventId,
            AppUserId = model.AppUserId,
            FullName = model.FullName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            NumberOfPeople = model.NumberOfPeople,
            Notes = model.Notes,
            RegistrationDate = DateTime.UtcNow
        };

        await _unitOfWork.Repository<EventRegistration>().AddAsync(registration);

        var result = await _unitOfWork.CompleteAsync();

        if (result <= 0)
            return Result.Failure<EventRegistrationResponse>(new Error(500, "An error occurred while registering for the event"));

        var registrationWithEvent = await GetRegistrationWithEvent(registration.Id);

        if (registrationWithEvent == null)
            return Result.Failure<EventRegistrationResponse>(new Error(500, "Failed to retrieve the registration details"));

        var response = _mapper.Map<EventRegistration, EventRegistrationResponse>(registrationWithEvent);
        response.EventTitle = registrationWithEvent.Event.Title;

        return Result.Success(response);
    }

    private async Task<EventRegistration?> GetRegistrationWithEvent(int registrationId)
    {
        var spec = new BaseSpecifications<EventRegistration>
        {
            WhereCriteria = r => r.Id == registrationId,
            IncludesCriteria = [r => r.Event]
        };

        var registrations = await _unitOfWork.Repository<EventRegistration>().GetAllAsync(spec);
        return registrations.FirstOrDefault();
    }
}