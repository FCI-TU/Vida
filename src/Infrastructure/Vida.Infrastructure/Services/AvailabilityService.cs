using Vida.Application.Interfaces.Repositories;
using Vida.Application.Interfaces.Services;
using Vida.Domain.ErrorHandling;
using Vida.Domain.SpaceEntities;

namespace Vida.Infrastructure.Services;
public class AvailabilityService(IUnitOfWork unitOfWork) : IAvailabilityService
{
	public async Task<Result<IReadOnlyList<Availability>>> GetAvailabilitiesAsync()
	{
		var availabilities = await unitOfWork.Repository<Availability>().GetAllAsync();

		return Result.Success(availabilities);
	}
}