using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace E_Learning.Presentation.Controllers;

[Route("/api/student/{studentId}/lessons/{lessonId}/stlesson")]
[ApiController]
public class StudentLessonController : ControllerBase
{

    private readonly IServiceManager _service;
    public StudentLessonController(IServiceManager service) => _service = service;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetLessonsByStudent(Guid studentId)
    {
        var lessons = await _service.StudentLessonService.GetLessonsByStudent(studentId, trackChanges: false);
        return Ok(lessons);
    }

    [HttpGet("{stlessonId:guid}", Name = "StudentLessonById")]
    [Authorize]
    public async Task<IActionResult> GetLessonById([FromRoute] Guid stlessonId, [FromRoute] Guid studentId, [FromRoute] Guid lessonId)
    {
        var lesson = await _service.StudentLessonService.GetLesson(stlessonId, studentId, lessonId, trackChanges: false);
        return Ok(lesson);
    }
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize]
    public async Task<IActionResult> CreateStudentLesson([FromRoute] Guid studentId, [FromRoute] Guid lessonId,
    [FromBody] StudentLessonForCreation studentLesson)
    {
        if (studentLesson is null)
            return BadRequest("StudentLessonForCreation object is null");
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var createdStudentLesson = await _service.StudentLessonService.CreateStudentLesson(studentId, lessonId, studentLesson, trackChanges: false);

        // Return a 201 Created response with the route to get the created lesson
        return CreatedAtRoute("StudentLessonById", new { studentId, lessonId = createdStudentLesson.Id }, createdStudentLesson);
    }
    [HttpDelete("{sudentLessonId:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteStudentLesson([FromRoute] Guid sudentLessonId, [FromRoute] Guid lessonId, [FromRoute] Guid studentId)
    {
        await _service.StudentLessonService.DeleteStudentLesson(sudentLessonId, lessonId, studentId, trackChanges: false);
        return NoContent();
    }
    [HttpPut("{sudentLessonId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize]
    public async Task<IActionResult> UpdateStudentLesson([FromRoute] Guid sudentLessonId, [FromRoute] Guid lessonId, [FromRoute] Guid studentId,
     StudentLessonForUpdateDto studentLessonForUpdate)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.StudentLessonService.UpdateStudntLesson(sudentLessonId, lessonId, studentId, studentLessonForUpdate,
           stlTrackChanges: true, stuTrackChanges: false, lessonTrackChanges: false);
        return NoContent();
    }


}