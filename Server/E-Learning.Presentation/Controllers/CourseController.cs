using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("api/courses")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly IServiceManager _service;
    public CourseController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetCourses()
    {
        var courses = _service.CourseService.GetAllCourses(trackChanges: false);
        return Ok(courses);
    }
}