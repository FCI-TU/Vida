using Vida.Domain.Common;
using Vida.Domain.Entities.IdentityEntities;

namespace Vida.Domain.SpaceEntities;
public class CourseReservation: BaseEntity
{
	public string AppUserId { get; set; } = null!;

	public AppUser AppUser { get; set; } = null!;

	public int CourseId { get; set; }

	public Course Course { get; set; } = null!;
}