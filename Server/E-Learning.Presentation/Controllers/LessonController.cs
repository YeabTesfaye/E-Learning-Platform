using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace E_Learning.Presentation.Controllers;

[Route("/api/module/{moduleId}/lessons")]
[ApiController]
public class LessonController(IServiceManager service) : ControllerBase
{
    private readonly IServiceManager _service = service;

    [HttpGet]
    public async Task<IActionResult> GetLessonsByModule([FromRoute] Guid moduleId)
    {
        var lessons = await _service.LessonService.GetLessonsByModule(moduleId, trackChanges: false);
        return Ok(lessons);
    }

    [HttpGet("{Id:guid}", Name = "LessonById")]
    // [Authorize]
    public async Task<IActionResult> GetLessonById([FromRoute] Guid Id, [FromRoute] Guid moduleId)
    {
        var lesson = await _service.LessonService.GetLesson(Id, moduleId, trackChanges: false);
        return Ok(lesson);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    // [Authorize]
    public async Task<IActionResult> CreateLesson([FromRoute] Guid moduleId, [FromBody] LessonForCreation lesson)
    {
        if (lesson is null)
            return BadRequest("LessonForCreation object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var lessonToReturn = await _service.LessonService.CreateLesson(moduleId, lesson, trackChanges: false);

        // Ensure route parameters are named the same as in the route definition (Id = Id, moduleId = moduleId)
        return CreatedAtRoute("LessonById", new { Id = lessonToReturn.Id, moduleId }, lessonToReturn);
    }
    [HttpDelete("{lessonId:guid}")]
    // [Authorize]

    public async Task<IActionResult> DeleteLesson([FromRoute] Guid lessonId, [FromRoute] Guid moduleId)
    {
        await _service.LessonService.DeleteLesson(lessonId, moduleId, trackChanges: false);
        return NoContent();
    }
    [HttpPut("{lessonId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    // [Authorize]
    public async Task<IActionResult> UpdateLesson([FromRoute] Guid lessonId, [FromRoute] Guid moduleId, LessonForUpdateDto lessonForUpdate)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        await _service.LessonService.UpdateLesson(lessonId, moduleId, lessonForUpdate, moduleTrackChanges: false, lessonTrackChanges: true);
        return NoContent();
    }


}