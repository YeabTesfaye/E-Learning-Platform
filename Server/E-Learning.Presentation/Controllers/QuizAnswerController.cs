using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

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
    [HttpGet("{answerId:guid}", Name = "AnswerById")]
    public IActionResult GetAnswerById([FromRoute] Guid questionId, [FromRoute] Guid answerId)
    {
        var answer = _service.QuizAnswerService.GetAnswerById(questionId, answerId, trackChanges: false);
        return Ok(answer);
    }

    [HttpPost]
    public IActionResult CreateAnswer([FromRoute] Guid questionId, [FromBody] QuizAnswerForCreation quizAnswer)
    {
        if (quizAnswer is null)
            return BadRequest("QuizAnswerForCreation object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var quizAnswerToReturn = _service.QuizAnswerService.CreateAnswer(questionId, quizAnswer, trackChanges: false);

        // Return CreatedAtRoute with the correct route and newly created answer's id
        return CreatedAtRoute("AnswerById", new { questionId, answerId = quizAnswerToReturn.Id }, quizAnswerToReturn);
    }

}