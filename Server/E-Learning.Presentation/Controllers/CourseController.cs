using System.Text.Json;
using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;
using Shared.RequestFeatures;

namespace E_Learning.Presentation.Controllers;

[Route("api/courses")]
[ApiController]
public class CourseController(IServiceManager service) : ControllerBase
{
    private readonly IServiceManager _service = service;

    [HttpGet]
    public async Task<IActionResult> GetCourses([FromQuery] CourseParameters courseParameters)
    {
        var (courses, metaData) = await _service.CourseService.GetAllCourses(courseParameters, trackChanges: false);
        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(courses);
    }
    [HttpGet("{Id:guid}", Name = "CourseById")]
    public async Task<IActionResult> GetCourse([FromRoute] Guid Id)
    {
        var course = await _service.CourseService.GetCourse(Id, trackChanges: false);
        return Ok(course);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    // [Authorize]
    public async Task<IActionResult> CreateCourse(CourseForCreationDto course)
    {
        if (course is null)
            return BadRequest("CourseForCreationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var createdCourse = await _service.CourseService.CreateCourse(course);

        return CreatedAtRoute("CourseById", new { id = createdCourse.Id }, createdCourse);
    }
    [HttpDelete("{Id:guid}")]
    // [Authorize]
    public async Task<IActionResult> DeleteCourse([FromRoute] Guid Id)
    {
        await _service.CourseService.DeleteCourse(Id, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{Id:guid}")]
    // [Authorize]
    [ServiceFilter(typeof(ValidationFilterAttribute))]

    public async Task<IActionResult> UpdateCourse([FromRoute] Guid Id, CourseForUpdateDto courseForUpdate)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.CourseService.UpdateCourse(Id, courseForUpdate, trackChanges: true);
        return NoContent();
    }
}