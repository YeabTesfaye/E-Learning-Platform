using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace E_Learning.Presentation.Controllers;

[Route("/api/students/{studentId}/attempts")]
[ApiController]
public class StudentQuizAttemptController(IServiceManager service) : ControllerBase
{
    private readonly IServiceManager _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAttemptsByStudent([FromRoute] Guid studentId)
    {
        var attempts = await _service.QuizAttemptService.GetAttemptsByStudent(studentId, trackChanges: false);
        return Ok(attempts);
    }

    [HttpGet("{attemptId:guid}", Name = "QuizAttemptById")]
    public async Task<IActionResult> GetAttemptById([FromRoute] Guid studentId, [FromRoute] Guid attemptId)
    {
        var attempt = await _service.QuizAttemptService.GetAttemptById(studentId, attemptId, trackChanges: false);
        return Ok(attempt);
    }

    // Create a new quiz attempt for a specific student and quiz
    [HttpPost("{quizId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    // [Authorize]-
    public async Task<IActionResult> CreateAttempt([FromRoute] Guid studentId, [FromRoute] Guid quizId,
     [FromBody] QuizAttemptForCreation studentQuizAttempt)
    {
        if (studentQuizAttempt is null)
            return BadRequest("StudentQuizAttemptForCreation object is null");
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var createdAttempt = await _service.QuizAttemptService.CreateAttempt(studentId, quizId, studentQuizAttempt, trackChanges: false);

        return CreatedAtRoute("QuizAttemptById", new { studentId, attemptId = createdAttempt.Id }, createdAttempt);
    }

    [HttpDelete("{attemptId:guid}")]
    // [Authorize]
    public async Task<IActionResult> DeleteAttempt([FromRoute] Guid attemptId, [FromRoute] Guid studentId)
    {
        await _service.QuizAttemptService.DeleteStudentQuizAttempt(attemptId, studentId, trackChanges: false);
        return NoContent();
    }
    [HttpPut("{attemptId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    // [Authorize]
    public async Task<IActionResult> UpdateAttempt([FromRoute] Guid attemptId, [FromRoute] Guid studentId, QuizAttemptForUpdateDto studentQuizAttempt)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.QuizAttemptService.UpdateStudentQuizAttempt(attemptId, studentId, studentQuizAttempt,
          attemptTrackChanges: true, studentTrackChanges: false);
        return NoContent();
    }
}
