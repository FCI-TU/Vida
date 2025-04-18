using Microsoft.AspNetCore.Identity;

namespace Vida.Domain.Entities.IdentityEntities;
public class AppUser: IdentityUser
{
	public string DisplayName { get; set; } = null!;
}