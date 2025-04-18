using Vida.Application.Dtos.SpaceDtos;
using Vida.Domain.ErrorHandling;
using Vida.Domain.SpaceEntities;

namespace Vida.Application.Interfaces.Services;
public interface ISpaceService
{
	Task<Result<IReadOnlyList<SpaceResponse>>> GetSpacesAsync();
	Task<Result<SpaceResponse>> GetSpaceByIdAsync(int id);
	Task<Result<SpaceResponse>> DeleteSpaceAsync(int id);
	Task<Result<Space>> SpaceReservationAsync(SpaceReservationRequest model);
}