using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

namespace E_Learning.Presentation.Controllers;

[Route("/api/module/{moduleId}/lessons")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly IServiceManager _service;

    public LessonController(IServiceManager service) => _service = service;
    [HttpGet]
    public IActionResult GetLessonsByModule([FromRoute] Guid moduleId)
    {
        var lessons = _service.LessonService.GetLessonsByModule(moduleId, trackChanges: false);
        return Ok(lessons);
    }

    [HttpGet("{Id:guid}", Name = "LessonById")]
    public IActionResult GetLessonById([FromRoute] Guid Id, [FromRoute] Guid moduleId)
    {
        var lesson = _service.LessonService.GetLesson(Id, moduleId, trackChanges: false);
        return Ok(lesson);
    }

    [HttpPost]
    public IActionResult CreateLesson([FromRoute] Guid moduleId, [FromBody] LessonForCreation lesson)
    {
        if (lesson is null)
            return BadRequest("LessonForCreation object is null");

        var lessonToReturn = _service.LessonService.CreateLesson(moduleId, lesson, trackChanges: false);

        // Ensure route parameters are named the same as in the route definition (Id = Id, moduleId = moduleId)
        return CreatedAtRoute("LessonById", new { Id = lessonToReturn.Id, moduleId }, lessonToReturn);
    }
    [HttpDelete("{lessonId:guid}")]

    public IActionResult DeleteLesson([FromRoute] Guid lessonId, [FromRoute] Guid moduleId)
    {
        _service.LessonService.DeleteLesson(lessonId, moduleId, trackChanges: false);
        return NoContent();
    }


}