using Microsoft.AspNetCore.Mvc;
using Vida.Application.Dtos.CourseDtos;
using Vida.Application.Dtos.SpaceDtos;
using Vida.Application.Interfaces.Services;
using Vida.Infrastructure.Services;
using Vida.Server.Extensions;

namespace Vida.Server.Controllers;
public class SpaceController(ISpaceService spaceService) : BaseController
{
	[HttpGet]
	public async Task<ActionResult> GetSpaces()
	{
		var result = await spaceService.GetSpacesAsync();

		return Ok(result.Value);
	}

	//[HttpGet("{id:int}")]
	//public async Task<ActionResult> GetSpaceById(int id)
	//{
	//	var result = await spaceService.GetSpaceByIdAsync(id);

	//	return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	//}
	
	//[HttpDelete("{id:int}")]
	//public async Task<ActionResult> DeleteSpace(int id)
	//{
	//	var result = await spaceService.DeleteSpaceAsync(id);

	//	return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	//}

	[HttpPost("space-reservation")]
	public async Task<ActionResult> SpaceReservation(SpaceReservationRequest model)
	{
		var result = await spaceService.SpaceReservationAsync(model);

		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

}
