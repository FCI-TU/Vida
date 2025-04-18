using Vida.Domain.Common;

namespace Vida.Domain.SpaceEntities;
public class Course: BaseEntity
{
	public string Title { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public string Type { get; set; } = string.Empty;

	public string ImageUrl { get; set; } = string.Empty;

	public decimal Price { get; set; }

	public string InstructorEmail { get; set; } = string.Empty;

	public int MaxParticipants { get; set; }

	public string Notes { get; set; } = string.Empty;
	
	public bool IsActive { get; set; }

	public int AvailabilityId { get; set; }

	public Availability Availability { get; set; } = null!;
}