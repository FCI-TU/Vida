using Vida.Domain.Common;
using Vida.Domain.Entities.IdentityEntities;

namespace Vida.Domain.SpaceEntities;
public class SpaceReservation : BaseEntity
{
	public int AvailabilityId { get; set; }

	public Availability Availability { get; set; } = null!;

	public int SpaceId { get; set; }

	public Space Space { get; set; } = null!;

	public string AppUserId { get; set; } = string.Empty;

	public AppUser AppUser { get; set; } = null!;
}