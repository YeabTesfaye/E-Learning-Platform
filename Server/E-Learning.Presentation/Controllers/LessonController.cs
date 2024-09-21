using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("api/module/{moduleId}/lesson")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly IServiceManager _service;

    public LessonController(IServiceManager service) => _service = service;
    [HttpGet]
    public IActionResult GetLessons(Guid moduleId){
        var lessons = _service.LessonService.GetLessons(moduleId, trackChanges:false);
        return Ok(lessons);
    }
    
}