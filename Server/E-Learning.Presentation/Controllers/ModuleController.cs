using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("api/modules")]
[ApiController]
public class ModuleController : ControllerBase
{
    private readonly IModuleService _moduleService;
    private readonly ILoggerManager _logger;
    public ModuleController(IModuleService moduleService, ILoggerManager logger)
    {
        _logger = logger;
        _moduleService = moduleService;
    }
    [HttpGet]
    public IActionResult GetAllCourses()
    {
        var courses = _moduleService.GetAllModules(trackChanges:false);
        return Ok(courses);
    }
}