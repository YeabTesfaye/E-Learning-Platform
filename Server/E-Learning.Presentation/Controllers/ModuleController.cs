using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("/api/course/{courseId}/module")]
[ApiController]
public class ModuleController : ControllerBase
{
    private readonly IServiceManager _service;
    public ModuleController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetModelForCourse(Guid courseId)
    {
        var modules = _service.ModuleService.GetModules(courseId, trackChanges:false);
        return Ok(modules);
    }
    
}