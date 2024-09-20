using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("api/students")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IServiceManager _service;

    public StudentController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetStudents()
    {
        var students = _service.StudentService.GetAllStudents(trackChanges: false);
        return Ok(students);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetStudent(Guid id)
    {
        var student = _service.StudentService.GetStudent(id, trackChanges: false);
        return Ok(student);
    }
}