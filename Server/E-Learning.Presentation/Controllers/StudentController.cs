using System.Text.Json;
using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.RequestFeatures;

namespace E_Learning.Presentation.Controllers;

[Route("api/students")]
[ApiController]
public class StudentController(IServiceManager service) : ControllerBase
{
    private readonly IServiceManager _service = service;

    [HttpGet(Name = "GetStudentes")]
    public async Task<IActionResult> GetStudents([FromQuery] StudentParameters studentParameters)
    {
        // return Ok(studentParameters);
        var (students, metaData) = await _service.StudentService.GetAllStudents(studentParameters, trackChanges: false);

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(students);
    }

    [HttpGet("{Id:guid}", Name = "StudentById")]
    public async Task<IActionResult> GetStudent([FromRoute] Guid Id)
    {
        var student = await _service.StudentService.GetStudent(Id, trackChanges: false);
        return Ok(student);
    }
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize]
    public async Task<IActionResult> CreateStudent([FromBody] StudentForCreation student)
    {
        var createdStudent = await _service.StudentService.CreateStudent(student);
        return CreatedAtRoute("StudentById", new { id = createdStudent.Id },
        createdStudent);
    }
    [HttpDelete("{studentId:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteStudent([FromRoute] Guid studentId)
    {
        await _service.StudentService.DeleteStudent(studentId, trackChanges: false);
        return NoContent();
    }


}