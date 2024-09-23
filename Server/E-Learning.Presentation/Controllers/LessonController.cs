using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

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

    [HttpGet("{Id:guid}",Name ="LessonById")]
    public IActionResult GetLessonById([FromRoute] Guid Id,[FromRoute] Guid moduleId)
    {
        var lesson = _service.LessonService.GetLesson(Id,moduleId, trackChanges: false);
        return Ok(lesson);
    }

}