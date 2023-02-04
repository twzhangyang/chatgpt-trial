using Microsoft.AspNetCore.Mvc;
using School.Api.Models;
using School.Api.Models.NewStudent;
using School.Api.NewRepository;

namespace School.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;

    public CourseController(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseResponse>>> GetCourses()
    {
        var courses = await _courseRepository.GetCourses();
        return Ok(courses.Select(c => c.ToCourseResponse()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseResponse>> GetCourse(string id)
    {
        var course = await _courseRepository.GetCourseById(int.Parse(id));

        if (course != null)
        {
            return Ok(course.ToCourseResponse());
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<CourseResponse>> CreateCourse(CourseRequest courseRequest)
    {
        var course = courseRequest.ToCourse();
        _courseRepository.AddCourse(course);
        return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, course.ToCourseResponse());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(string id, CourseRequest courseRequest)
    {
        if (id != courseRequest.CourseId)
        {
            return BadRequest();
        }

        var course = courseRequest.ToCourse();
        _courseRepository.UpdateCourse(course);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(string id)
    {
        var course = await _courseRepository.GetCourseById(int.Parse(id));
        _courseRepository.DeleteCourse(course);

        return NoContent();
    }
}
