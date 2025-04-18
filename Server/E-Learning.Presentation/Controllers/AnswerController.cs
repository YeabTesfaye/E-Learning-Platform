using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

namespace E_Learning.Presentation.Controllers;

[Route("/api/questions/{questionId}/answers")]
[ApiController]
public class AnswerController(IServiceManager service) : ControllerBase
{
    private readonly IServiceManager _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAnswersByQuestion(Guid questionId)
    {
        var answers = await _service.AnswerService.GetAnswersByQuestion(questionId, trackChanges: false);
        return Ok(answers);
    }

    [HttpGet("{answerId:guid}", Name = "AnswerById")]
    public async Task<IActionResult> GetAnswerById([FromRoute] Guid questionId, [FromRoute] Guid answerId)
    {
        var answer = await _service.AnswerService.GetAnswerById(answerId, questionId, trackChanges: false);
        return Ok(answer);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize]
    public async Task<IActionResult> CreateAnswer([FromRoute] Guid questionId, [FromBody] AnswerForCreation answer)
    {

        var quizAnswerToReturn = await _service.AnswerService.CreateAnswer(questionId, answer, trackChanges: false);

        // Return CreatedAtRoute with the correct route and newly created answer's id
        return CreatedAtRoute("AnswerById", new { questionId, answerId = quizAnswerToReturn.Id }, quizAnswerToReturn);
    }
    [HttpDelete("{answerId:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteQuizAnswer([FromRoute] Guid answerId, [FromRoute] Guid questionId)
    {
        await _service.AnswerService.DeleteQuizAnswer(answerId, questionId, trackChanges: false);
        return NoContent();
    }
  

}