using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("/api/modules/{moduleId}/lessons")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly IServiceManager _service;

    public LessonController(IServiceManager service) => _service = service;
    [HttpGet]
    public IActionResult GetLessonsByModule(Guid moduleId)
    {
        var lessons = _service.LessonService.GetLessonsByModule(moduleId, trackChanges: false);
        return Ok(lessons);
    }

    // Get a specific lesson by lessonId
    [HttpGet("{lessonId:guid}")]
    public IActionResult GetLessonById(Guid lessonId)
    {
        var lesson = _service.LessonService.GetLessonById(lessonId, trackChanges: false);
        return Ok(lesson);
    }

}