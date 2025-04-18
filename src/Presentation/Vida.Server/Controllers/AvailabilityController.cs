using Microsoft.AspNetCore.Mvc;
using Vida.Application.Interfaces.Services;

namespace Vida.Server.Controllers;
public class AvailabilityController(IAvailabilityService availabilityService) : BaseController
{
	[HttpGet]
	public async Task<ActionResult> GetAvailabilities()
	{
		var result = await availabilityService.GetAvailabilitiesAsync();

		return Ok(result.Value);
	}
}
