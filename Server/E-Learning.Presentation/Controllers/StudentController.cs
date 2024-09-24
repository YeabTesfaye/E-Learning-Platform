using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

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

    [HttpGet("{Id:guid}", Name = "StudentById")]
    public IActionResult GetStudent([FromRoute] Guid Id)
    {
        var student = _service.StudentService.GetStudent(Id, trackChanges: false);
        return Ok(student);
    }
    [HttpPost]
    public IActionResult CreateStudent([FromBody] StudentForCreation student)
    {
        if (student is null)
            return BadRequest("StudentForCreation object is null");

        var createdStudent = _service.StudentService.CreateStudent(student);
        return CreatedAtRoute("StudentById", new { id = createdStudent.Id },
        createdStudent);
    }
    [HttpDelete("{studentId:guid}")]
    public IActionResult DeleteStudent([FromRoute] Guid studentId)
    {
        _service.StudentService.DeleteStudent(studentId, trackChanges: false);
        return NoContent();
    }
}