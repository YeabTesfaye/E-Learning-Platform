using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

namespace E_Learning.Presentation.Controllers;

[Route("/api/students/{studentId}/attempts")]
[ApiController]
public class StudentQuizAttemptController : ControllerBase
{
    private readonly IServiceManager _service;

    public StudentQuizAttemptController(IServiceManager service) => _service = service;

    // Get all quiz attempts by a specific student
    [HttpGet]
    public IActionResult GetAttemptsByStudent([FromRoute] Guid studentId)
    {
        var attempts = _service.StudentQuizAttemptService.GetAttemptsByStudent(studentId, trackChanges: false);
        return Ok(attempts);
    }

    // Get a specific quiz attempt by studentId and attemptId
    [HttpGet("{attemptId:guid}", Name = "QuizAttemptById")]
    public IActionResult GetAttemptById([FromRoute] Guid studentId, [FromRoute] Guid attemptId)
    {
        var attempt = _service.StudentQuizAttemptService.GetAttemptById(studentId, attemptId, trackChanges: false);
        return Ok(attempt);
    }

    // Create a new quiz attempt for a specific student and quiz
    [HttpPost("{quizId:guid}")]
    public IActionResult CreateAttempt([FromRoute] Guid studentId, [FromRoute] Guid quizId,
     [FromBody] StudentQuizAttemptForCreation studentQuizAttempt)
    {
        if (studentQuizAttempt is null)
            return BadRequest("StudentQuizAttemptForCreation object is null");

        var createdAttempt = _service.StudentQuizAttemptService.CreateAttempt(studentId, quizId, studentQuizAttempt, trackChanges: false);

        return CreatedAtRoute("QuizAttemptById", new { attemptId = createdAttempt.Id }, createdAttempt);
    }
}
