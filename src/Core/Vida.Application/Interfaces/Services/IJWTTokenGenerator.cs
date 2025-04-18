using Microsoft.AspNetCore.Identity;
using Vida.Domain.Entities.IdentityEntities;

namespace Vida.Application.Interfaces.Services;
public interface IJWTTokenGenerator
{
	Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager);
}