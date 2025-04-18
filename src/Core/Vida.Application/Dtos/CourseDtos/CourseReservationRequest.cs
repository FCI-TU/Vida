namespace Vida.Application.Dtos.CourseDtos;
public class CourseReservationRequest
{
	public string AppUserId { get; set; } = null!;

	public int CourseId { get; set; }
}