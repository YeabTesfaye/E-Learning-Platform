using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace E_Learning.Presentation.Controllers;

[Route("/api/students/{studentId}/attempts")]
[ApiController]
public class StudentQuizAttemptController : ControllerBase
{
    private readonly IServiceManager _service;

    public StudentQuizAttemptController(IServiceManager service) => _service = service;

    // Get all quiz attempts by a specific student
    [HttpGet]
    public async Task<IActionResult> GetAttemptsByStudent([FromRoute] Guid studentId)
    {
        var attempts = await _service.StudentQuizAttemptService.GetAttemptsByStudent(studentId, trackChanges: false);
        return Ok(attempts);
    }

    // Get a specific quiz attempt by studentId and attemptId
    [HttpGet("{attemptId:guid}", Name = "QuizAttemptById")]
    public async Task<IActionResult> GetAttemptById([FromRoute] Guid studentId, [FromRoute] Guid attemptId)
    {
        var attempt = await _service.StudentQuizAttemptService.GetAttemptById(studentId, attemptId, trackChanges: false);
        return Ok(attempt);
    }

    // Create a new quiz attempt for a specific student and quiz
    [HttpPost("{quizId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAttempt([FromRoute] Guid studentId, [FromRoute] Guid quizId,
     [FromBody] StudentQuizAttemptForCreation studentQuizAttempt)
    {
        if (studentQuizAttempt is null)
            return BadRequest("StudentQuizAttemptForCreation object is null");
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var createdAttempt = await _service.StudentQuizAttemptService.CreateAttempt(studentId, quizId, studentQuizAttempt, trackChanges: false);

        return CreatedAtRoute("QuizAttemptById", new { studentId, attemptId = createdAttempt.Id }, createdAttempt);
    }

    [HttpDelete("{attemptId:guid}")]
    public async Task<IActionResult> DeleteAttempt([FromRoute] Guid attemptId, [FromRoute] Guid studentId)
    {
        await _service.StudentQuizAttemptService.DeleteStudentQuizAttempt(attemptId, studentId, trackChanges: false);
        return NoContent();
    }
    [HttpPut("{attemptId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateAttempt([FromRoute] Guid attemptId, [FromRoute] Guid studentId, StudentQuizAttemptForUpdateDto studentQuizAttempt)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.StudentQuizAttemptService.UpdateStudentQuizAttempt(attemptId, studentId, studentQuizAttempt,
          attemptTrackChanges: true, studentTrackChanges: false);
        return NoContent();
    }
}
