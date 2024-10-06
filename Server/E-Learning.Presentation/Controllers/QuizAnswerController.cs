using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace E_Learning.Presentation.Controllers;

[Route("/api/questions/{questionId}/answers")]
[ApiController]
public class QuizAnswerController : ControllerBase
{
    private readonly IServiceManager _service;

    public QuizAnswerController(IServiceManager service) => _service = service;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAnswersByQuestion(Guid questionId)
    {
        var answers = await _service.QuizAnswerService.GetAnswersByQuestion(questionId, trackChanges: false);
        return Ok(answers);
    }

    [HttpGet("{answerId:guid}", Name = "AnswerById")]
    [Authorize]
    public async Task<IActionResult> GetAnswerById([FromRoute] Guid questionId, [FromRoute] Guid answerId)
    {
        var answer = await _service.QuizAnswerService.GetAnswerById(questionId, answerId, trackChanges: false);
        return Ok(answer);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize]
    public async Task<IActionResult> CreateAnswer([FromRoute] Guid questionId, [FromBody] QuizAnswerForCreation quizAnswer)
    {
        if (quizAnswer is null)
            return BadRequest("QuizAnswerForCreation object is null");

        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }


        var quizAnswerToReturn = await _service.QuizAnswerService.CreateAnswer(questionId, quizAnswer, trackChanges: false);

        // Return CreatedAtRoute with the correct route and newly created answer's id
        return CreatedAtRoute("AnswerById", new { questionId, answerId = quizAnswerToReturn.Id }, quizAnswerToReturn);
    }
    [HttpDelete("{answerId:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteQuizAnswer([FromRoute] Guid answerId, [FromRoute] Guid questionId)
    {
        await _service.QuizAnswerService.DeleteQuizAnswer(answerId, questionId, trackChanges: false);
        return NoContent();
    }
    [HttpPut("{answerId:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize]
    public async Task<IActionResult> UpdateQuizAnswer([FromRoute] Guid answerId, [FromRoute] Guid questionId, QuizAnswerForUpdateDto quizAnswerForUpdate)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.QuizAnswerService.UpdateQuizAnswer(answerId, questionId, quizAnswerForUpdate, questionTrackChanges: false, quizTrackChanges: true);
        return NoContent();
    }

}