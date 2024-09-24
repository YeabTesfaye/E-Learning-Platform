using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

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
    [HttpGet("{Id:guid}", Name = "CourseById")]
    public IActionResult GetCourse([FromRoute] Guid Id)
    {
        var course = _service.CourseService.GetCourse(Id, trackChanges: false);
        return Ok(course);
    }

    [HttpPost]
    public IActionResult CreateCourse(CourseForCreationDto course)
    {
        var createdCourse = _service.CourseService.CreateCourse(course);
        return CreatedAtRoute("CourseById", new { id = createdCourse.Id },
               createdCourse);
    }
    [HttpDelete("{courseId:guid}")]
    public IActionResult DeleteCourse([FromRoute] Guid courseId)
    {
        _service.CourseService.DeleteCourse(courseId, trackChanges: false);
        return NoContent();
    }
}