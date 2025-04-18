namespace Vida.Application.Dtos.SpaceDtos;
public class SpaceReservationRequest
{
	public int AvailabilityId { get; set; }

	public int SpaceId { get; set; }

	public string AppUserId { get; set; }
}