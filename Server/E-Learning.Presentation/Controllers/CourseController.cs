using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace E_Learning.Presentation.Controllers;

[Route("api/courses")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly IServiceManager _service;
    public CourseController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _service.CourseService.GetAllCourses(trackChanges: false);
        return Ok(courses);
    }
    [HttpGet("{Id:guid}", Name = "CourseById")]
    public async Task<IActionResult> GetCourse([FromRoute] Guid Id)
    {
        var course = await _service.CourseService.GetCourse(Id, trackChanges: false);
        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CourseForCreationDto course)
    {
        if (course is null)
            return BadRequest("CourseForCreationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var createdCourse = await _service.CourseService.CreateCourse(course);


        return CreatedAtRoute("CourseById", new { id = createdCourse.Id },
               createdCourse);
    }
    [HttpDelete("{Id:guid}")]
    public async Task<IActionResult> DeleteCourse([FromRoute] Guid Id)
    {
        await _service.CourseService.DeleteCourse(Id, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> UpdateCourse([FromRoute] Guid Id, CourseForUpdateDto courseForUpdate)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.CourseService.UpdateCourse(Id, courseForUpdate, trackChanges: true);
        return NoContent();
    }
}