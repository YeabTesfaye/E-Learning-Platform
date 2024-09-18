using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("api/instructors")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly IInstructorService _instructorService;
    private readonly ILoggerManager _logger;
    public InstructorController(IInstructorService instructorService, ILoggerManager logger)
    {
        _instructorService = instructorService;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult GetAllInstructors()
    {
        var courses = _instructorService.GetAllInstructors(trackChanges:false);
        return Ok(courses);
    }
}