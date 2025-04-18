using Microsoft.AspNetCore.Mvc;
using Vida.Application.Dtos.IdentityDtos;
using Vida.Application.Interfaces.Services;
using Vida.Domain.ErrorHandling;
using Vida.Server.Extensions;

namespace Vida.Server.Controllers;
public class AuthController(IAuthService authService) : BaseController
{
	[HttpPost("register")]
	public async Task<ActionResult<Result>> Register(RegisterRequest model)
	{
		var result = await authService.Register(model);

		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpPost("login")]
	public async Task<ActionResult<Result>> Login(LoginRequest model)
	{
		var result = await authService.Login(model);

		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}
}
