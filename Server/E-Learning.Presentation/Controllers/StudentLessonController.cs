using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

namespace E_Learning.Presentation.Controllers;

[Route("/api/student/{studentId}/lessons/{lessonId}/stlesson")]
[ApiController]
public class StudentLessonController(IServiceManager service) : ControllerBase
{

    private readonly IServiceManager _service = service;

    [HttpGet]
    public async Task<IActionResult> GetLessonsByStudent([FromRoute] Guid studentId, [FromRoute] Guid lessonId)
    {
        var lessons = await _service.StudentLessonService.GetLessonsByStudent(studentId, lessonId, trackChanges: true);
        return Ok(lessons);
    }

    [HttpGet("{stlessonId:guid}", Name = "StudentLessonById")]
    public async Task<IActionResult> GetLessonById([FromRoute] Guid stlessonId, [FromRoute] Guid studentId, [FromRoute] Guid lessonId)
    {
        var lesson = await _service.StudentLessonService.GetStudentLesson(stlessonId, lessonId, studentId, trackChanges: false);
        return Ok(lesson);
    }
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize]
    public async Task<IActionResult> CreateStudentLesson([FromRoute] Guid studentId, [FromRoute] Guid lessonId,
    [FromBody] StudentLessonForCreation studentLesson)
    {


        var createdStudentLesson = await _service.StudentLessonService.CreateStudentLesson(studentId, lessonId, studentLesson, trackChanges: false);

        // Return a 201 Created response with the route to get the created lesson
        return CreatedAtRoute("StudentLessonById",
      new { studentId, lessonId, stlessonId = createdStudentLesson.Id }, createdStudentLesson);

    }
    [HttpDelete("{stlessonId:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteStudentLesson([FromRoute] Guid stlessonId, [FromRoute] Guid studentId, [FromRoute] Guid lessonId)
    {
        await _service.StudentLessonService.DeleteStudentLesson(stlessonId, lessonId, studentId, trackChanges: false);
        return NoContent();
    }



}