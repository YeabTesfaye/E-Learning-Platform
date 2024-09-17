using Microsoft.AspNetCore.Mvc;
using Service;

namespace E_Learning.Presentation.Controllers;


[Route("api/students")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IServiceManager _service;
    public StudentController (IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetStudenties()
    {
        try
        {
            var studenties = 
            _service.StudentService.GetAllStudents(trackChanges:false);
            return Ok(studenties);
        }
        catch 
        {
            return StatusCode(500,"Internal Service Error ");
        }
    }
}