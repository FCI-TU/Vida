using Vida.Application.Dtos.CourseDtos;
using Vida.Domain.ErrorHandling;
using Vida.Domain.SpaceEntities;

namespace Vida.Application.Interfaces.Services;
public interface ICourseService
{
	Task<Result<IReadOnlyList<Course>>> GetCoursesAsync();
	Task<Result<Course>> CourseReservationAsync(CourseReservationRequest model);

    Task<Result<IReadOnlyList<Course>>> GetCoursesByCategoryAsync(string category);

    Task<Result<IReadOnlyList<string>>> GetAvailableCategoriesAsync();
}