using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("/api/questions/{questionId}/answers")]
[ApiController]
public class QuizAnswerController : ControllerBase
{
    private readonly IServiceManager _service;

    public QuizAnswerController(IServiceManager service) => _service = service;

    // Get all answers for a specific question
    [HttpGet]
    public IActionResult GetAnswersByQuestion(Guid questionId)
    {
        var answers = _service.QuizAnswerService.GetAnswersByQuestion(questionId, trackChanges: false);
        return Ok(answers);
    }

    // Get a specific answer by questionId and answerId
    [HttpGet("{answerId:guid}")]
    public IActionResult GetAnswerById(Guid questionId, Guid answerId)
    {
        var answer = _service.QuizAnswerService.GetAnswerById(questionId, answerId, trackChanges: false);
        return Ok(answer);
    }
}