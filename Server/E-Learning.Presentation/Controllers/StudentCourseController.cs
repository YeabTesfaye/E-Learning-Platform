using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("api/studentCourses")]
[ApiController]
public class StudentCourseController : ControllerBase
{
    private readonly IStudentCourseService _studentCourseService;
    private readonly ILoggerManager _logger;
    public StudentCourseController(IStudentCourseService studentCourseService, ILoggerManager logger)
    {
        _studentCourseService = studentCourseService;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult GetAllStudentCourses()
    {
        var courses = _studentCourseService.GetAllStudentCourses(trackChanges:false);
        return Ok(courses);
    }
}