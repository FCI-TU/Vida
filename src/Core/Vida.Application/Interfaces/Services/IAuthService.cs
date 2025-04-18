using Vida.Application.Dtos.IdentityDtos;
using Vida.Domain.ErrorHandling;

namespace Vida.Application.Interfaces.Services;
public interface IAuthService
{
	Task<Result<AppUserResponse>> Login(LoginRequest model);
	Task<Result<AppUserResponse>> Register(RegisterRequest model);
}