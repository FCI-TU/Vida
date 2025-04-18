using AutoMapper;
using Vida.Application.Dtos.CourseDtos;
using Vida.Application.Dtos.SpaceDtos;
using Vida.Application.Interfaces.Repositories;
using Vida.Application.Interfaces.Services;
using Vida.Domain.ErrorHandling;
using Vida.Domain.SpaceEntities;

namespace Vida.Infrastructure.Services;
public class SpaceService(IUnitOfWork unitOfWork, IMapper mapper) : ISpaceService
{
	public async Task<Result<IReadOnlyList<SpaceResponse>>> GetSpacesAsync()
	{
		var spaces = await unitOfWork.Repository<Space>().GetAllAsync();

		var spacesDto = mapper.Map<IReadOnlyList<Space>, IReadOnlyList<SpaceResponse>>(spaces);

		return Result.Success(spacesDto);
	}

	public async Task<Result<Space>> SpaceReservationAsync(SpaceReservationRequest model)
	{
		var spaceReservation = mapper.Map<SpaceReservationRequest, SpaceReservation>(model);

		await unitOfWork.Repository<SpaceReservation>().AddAsync(spaceReservation);

		var result = await unitOfWork.CompleteAsync();

		if (result <= 0)
			return Result.Failure<Space>(new Error(500, "An error occurred while reserving the course"));

		var space = await unitOfWork.Repository<Space>().GetEntityAsync(spaceReservation.SpaceId);

		if (space == null)
			return Result.Failure<Space>(new Error(404, $"Space with id {spaceReservation.SpaceId} not found"));

		return Result.Success(space);
	}

	public async Task<Result<SpaceResponse>> GetSpaceByIdAsync(int id)
	{
		var space = await unitOfWork.Repository<Space>().GetEntityAsync(id);

		if (space == null)
			return Result.Failure<SpaceResponse>(new Error(404, $"Space with id {id} not found"));

		var spaceDto = mapper.Map<Space, SpaceResponse>(space);

		return Result.Success(spaceDto);
	}

	public async Task<Result<SpaceResponse>> DeleteSpaceAsync(int id)
	{
		var space = await unitOfWork.Repository<Space>().GetEntityAsync(id);

		if (space == null)
			return Result.Failure<SpaceResponse>(new Error(404, $"Space with id {id} not found"));

		unitOfWork.Repository<Space>().Delete(space);

		await unitOfWork.CompleteAsync();

		var spaceDto = mapper.Map<Space, SpaceResponse>(space);

		return Result.Success(spaceDto);
	}
}