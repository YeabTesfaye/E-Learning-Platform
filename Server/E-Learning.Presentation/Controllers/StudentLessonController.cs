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
    public IActionResult GetLessonsByStudent(Guid studentId)
    {
        var lessons = _service.StudentLessonService.GetLessonsByStudent(studentId, trackChanges: false);
        return Ok(lessons);
    }

    // Get a specific lesson completed by studentId and lessonId
    [HttpGet("{stlessonId:guid}", Name = "StudentLessonById")]
    public IActionResult GetLessonById([FromRoute] Guid stlessonId, [FromRoute] Guid studentId, [FromRoute] Guid lessonId)
    {
        var lesson = _service.StudentLessonService.GetLesson(stlessonId, studentId, lessonId, trackChanges: false);
        return Ok(lesson);
    }
    [HttpPost]
    public IActionResult CreateStudentLesson([FromRoute] Guid studentId, [FromRoute] Guid lessonId,
    [FromBody] StudentLessonForCreation studentLesson)
    {
        if (studentLesson is null)
            return BadRequest("StudentLessonForCreation object is null");

        var createdStudentLesson = _service.StudentLessonService.CreateStudentLesson(studentId, lessonId, studentLesson, trackChanges: false);

        // Return a 201 Created response with the route to get the created lesson
        return CreatedAtRoute("StudentLessonById", new { studentId, lessonId = createdStudentLesson.Id }, createdStudentLesson);
    }
    [HttpDelete("{sudentLessonId:guid}")]
    public IActionResult DeleteStudentLesson([FromRoute] Guid sudentLessonId, [FromRoute] Guid lessonId, [FromRoute] Guid studentId)
    {
        _service.StudentLessonService.DeleteStudentLesson(sudentLessonId, lessonId, studentId, trackChanges: false);
        return NoContent();
    }
    [HttpPut("{sudentLessonId:guid}")]
    public IActionResult UpdateStudentLesson([FromRoute] Guid sudentLessonId, [FromRoute] Guid lessonId, [FromRoute] Guid studentId,
     StudentLessonForUpdateDto studentLessonForUpdate)
    {
        _service.StudentLessonService.UpdateStudntLesson(sudentLessonId, lessonId, studentId, studentLessonForUpdate,
        stlTrackChanges: true, stuTrackChanges: false, lessonTrackChanges: false);
        return NoContent();
    }


}