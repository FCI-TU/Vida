using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vida.Application.Interfaces.Services;
using Vida.Application.Models;
using Vida.Domain.Entities.IdentityEntities;

namespace Vida.Infrastructure.Services;
public class JWTTokenGenerator(IOptions<JwtOptions> jwtOptions) : IJWTTokenGenerator
{
	private readonly JwtOptions _jwtOptions = jwtOptions.Value;

	public async Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager)
	{
		// Private Claims

		var authClaims = new List<Claim>
		{
			new(ClaimTypes.GivenName, user.UserName ?? ""),
			new(ClaimTypes.Email, user.Email ?? "")
		};

		var userRoles = await userManager.GetRolesAsync(user);

		foreach (var role in userRoles)
		{
			authClaims.Add(new Claim(ClaimTypes.Role, role));
		}

		// secret key
		var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));

		// Token Object
		var token = new JwtSecurityToken(
			
			// Registered Claims
			issuer: _jwtOptions.ValidIssuer,
			audience: _jwtOptions.ValidAudience,
			expires: DateTime.UtcNow.AddDays(double.Parse(_jwtOptions.DurationInDays)),
			
			// Private Claims
			claims: authClaims,
			signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
		);

		// Create Token And Return It
		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}