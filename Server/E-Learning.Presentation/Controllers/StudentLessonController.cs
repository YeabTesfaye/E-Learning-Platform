using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

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
        var lesson = await _service.StudentLessonService.GetLesson(stlessonId, studentId, lessonId, trackChanges: false);
        return Ok(lesson);
    }
    [HttpPost]
    // [ServiceFilter(typeof(ValidationFilterAttribute))]
    // [Authorize]
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
        return CreatedAtRoute("StudentLessonById",
      new { studentId, lessonId, stlessonId = createdStudentLesson.Id }, createdStudentLesson);

    }
    [HttpDelete("{stlessonId:guid}")]
    // [Authorize]
    public async Task<IActionResult> DeleteStudentLesson([FromRoute] Guid stlessonId, [FromRoute] Guid lessonId, [FromRoute] Guid studentId)
    {
        await _service.StudentLessonService.DeleteStudentLesson(stlessonId, lessonId, studentId, trackChanges: false);
        return NoContent();
    }
    [HttpPut("{stlessonId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    // [Authorize]
    public async Task<IActionResult> UpdateStudentLesson([FromRoute] Guid stlessonId, [FromRoute] Guid lessonId, [FromRoute] Guid studentId,
     StudentLessonForUpdateDto studentLessonForUpdate)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.StudentLessonService.UpdateStudntLesson(stlessonId, lessonId, studentId, studentLessonForUpdate,
           stlTrackChanges: true, stuTrackChanges: false, lessonTrackChanges: false);
        return NoContent();
    }


}