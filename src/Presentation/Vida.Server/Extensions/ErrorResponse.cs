namespace Vida.Server.Extensions;
public class ErrorResponse
{
	public int StatusCode { get; set; }
	public string Message { get; set; } = string.Empty;
}