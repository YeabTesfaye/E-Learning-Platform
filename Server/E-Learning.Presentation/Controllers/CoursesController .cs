using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;
[Route("api/courses")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly ILoggerManager _logger;

    public CoursesController(ICourseService courseService, ILoggerManager logger)
    {
        _courseService = courseService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllCourses()
    {
        var courses = _courseService.GetAllCoursesAsync();
        return Ok(courses);
    }
    [HttpGet("{id:Guid}")]
    public IActionResult GetCourseById([FromRoute] Guid id)
    {
        var course = _courseService.GetCourseByIdAsync(id);
        if (course == null)
            return NotFound();
        return Ok(course);
    }


}