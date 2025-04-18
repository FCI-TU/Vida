namespace Vida.Application.Dtos.IdentityDtos;
public class RegisterRequest
{
	public string DisplayName { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public string PhoneNumber { get; set; } = string.Empty;

	public string Password { get; set; } = string.Empty;
}