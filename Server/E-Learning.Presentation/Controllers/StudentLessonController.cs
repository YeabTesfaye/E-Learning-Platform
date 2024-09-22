using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("/api/student/{studentId}/lessons")]
[ApiController]
public class StudentLessonController : ControllerBase
{

    private readonly IServiceManager _service;
    public StudentLessonController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetLessonsByStudent(Guid studentId)
    {
        var lessons = _service.StudentLessonService.GetLessonsByStudent(studentId, trackChanges: false);
        return Ok(lessons);
    }

    // Get a specific lesson completed by studentId and lessonId
    [HttpGet("{lessonId:guid}")]
    public IActionResult GetLessonById(Guid studentId, Guid lessonId)
    {
        var lesson = _service.StudentLessonService.GetLessonById(studentId, lessonId, trackChanges: false);
        return Ok(lesson);
    }
}