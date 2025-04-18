using Microsoft.AspNetCore.Mvc;
using Vida.Application.Dtos.CourseDtos;
using Vida.Application.Interfaces.Services;
using Vida.Server.Extensions;

namespace Vida.Server.Controllers;
public class CourseController(ICourseService courseService) : BaseController
{
	[HttpGet]
	public async Task<ActionResult> GetCourses()
	{
		var result = await courseService.GetCoursesAsync();

		return Ok(result.Value);
	}

	[HttpPost("course-reservation")]
	public async Task<ActionResult> CourseReservation(CourseReservationRequest model)
	{
		var result = await courseService.CourseReservationAsync(model);

		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}
}
