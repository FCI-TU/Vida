using Vida.Application.Dtos.SpaceDtos;
using Vida.Domain.ErrorHandling;
using Vida.Domain.SpaceEntities;

namespace Vida.Application.Interfaces.Services;
public interface IAvailabilityService
{
	Task<Result<IReadOnlyList<Availability>>> GetAvailabilitiesAsync();
}