using Vida.Domain.Common;

namespace Vida.Domain.SpaceEntities;
public class Availability: BaseEntity
{
	public short DayOfWeek { get; set; }

	public TimeSpan OpenTime { get; set; }

	public TimeSpan CloseTime { get; set; }

	public bool IsActive { get; set; }
}