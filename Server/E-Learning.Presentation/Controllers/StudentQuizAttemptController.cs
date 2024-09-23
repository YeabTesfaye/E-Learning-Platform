using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("/api/students/{studentId}/attempts")]
[ApiController]
public class StudentQuizAttemptController : ControllerBase
{
    private readonly IServiceManager _service;

    public StudentQuizAttemptController(IServiceManager service) => _service = service;

    // Get all quiz attempts by a specific student
    [HttpGet]
    public IActionResult GetAttemptsByStudent(Guid studentId)
    {
        var attempts = _service.StudentQuizAttemptService.GetAttemptsByStudent(studentId, trackChanges: false);
        return Ok(attempts);
    }

    // Get a specific quiz attempt by studentId and attemptId
    [HttpGet("{attemptId:guid}", Name ="QuizAttemptById")]
    public IActionResult GetAttemptById([FromRoute] Guid studentId,[FromRoute] Guid attemptId)
    {
        var attempt = _service.StudentQuizAttemptService.GetAttemptById(studentId, attemptId, trackChanges: false);
        return Ok(attempt);
    }
}