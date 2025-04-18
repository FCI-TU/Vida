using Microsoft.AspNetCore.Identity;
using Vida.Application.Dtos.IdentityDtos;
using Vida.Application.Interfaces.Services;
using Vida.Domain.Entities.IdentityEntities;
using Vida.Domain.ErrorHandling;

namespace Vida.Infrastructure.Services;
public class AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJWTTokenGenerator tokenGenerator) : IAuthService
{
	public async Task<Result<AppUserResponse>> Login(LoginRequest model)
	{
		var user = await userManager.FindByEmailAsync(model.Email);

		if (user is null || model.Password is null)
			return Result.Failure<AppUserResponse>(new Error(400, "The email or password you entered is incorrect, Check your credentials and try again."));

		var hasPassword = await userManager.HasPasswordAsync(user);

		if (hasPassword is false)
			return Result.Failure<AppUserResponse>(new Error(400, "You need to reset your password."));

		var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);

		if (result.Succeeded is false)
		{
			return Result.Failure<AppUserResponse>(new Error(400, "The email or password you entered is incorrect, Check your credentials and try again."));
		}

		return Result.Success(new AppUserResponse
		{
			DisplayName = user.DisplayName,
			Email = model.Email,
			Token = await tokenGenerator.CreateTokenAsync(user, userManager)
		});
	}

	public async Task<Result<AppUserResponse>> Register(RegisterRequest model)
	{
		var isEmailExist = await CheckEmailExist(model.Email);

		if (isEmailExist)
			return Result.Failure<AppUserResponse>(new Error(400, "This email has already been used"));

		var user = new AppUser
		{
			DisplayName = model.DisplayName,
			Email = model.Email,
			UserName = model.Email.Split('@')[0],
			PhoneNumber = model.PhoneNumber,
		};

		var result = await userManager.CreateAsync(user, model.Password);

		if (result.Succeeded is false) return Result.Failure<AppUserResponse>(new Error(400, "Failed to register user"));

		return Result.Success(new AppUserResponse
		{
			DisplayName = user.DisplayName,
			Email = model.Email,
			Token = await tokenGenerator.CreateTokenAsync(user, userManager)
		});
	}

	private async Task<bool> CheckEmailExist(string email)
	{
		return await userManager.FindByEmailAsync(email) is not null;
	}

}