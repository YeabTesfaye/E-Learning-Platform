using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

namespace E_Learning.Presentation.Controllers;
[Route("/api/course/{courseId}/quiz")]
[ApiController]
public class QuizController(IServiceManager service) : ControllerBase
{
    private readonly IServiceManager _service = service;

    [HttpGet]
    public async Task<IActionResult> GetQuizzesForCourse([FromRoute] Guid courseId)
    {
        var quizzes = await _service.QuizService.GetQuizzes(courseId, trackChanges: false);
        return Ok(quizzes);
    }

    [HttpGet("{quizId:guid}", Name = "QuizById")]
    public async Task<IActionResult> GetQuizForCourse([FromRoute] Guid quizId, [FromRoute] Guid courseId)
    {
        var quiz = await _service.QuizService.GetQuiz(quizId,courseId, trackChanges: false);
        if(quiz is null) return NotFound();
        return Ok(quiz);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize]
    public async Task<IActionResult> CreateQuizForCourse([FromRoute] Guid courseId, [FromBody] QuizForCreation quiz)
    {
        var createdQuiz = await _service.QuizService.CreateQuiz(courseId, quiz, trackChanges: false);

        return CreatedAtRoute("QuizById", new { quizId = createdQuiz.Id, courseId }, createdQuiz);
    }
    [HttpDelete("{quizId:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteQuiz([FromRoute] Guid quizId, [FromRoute] Guid courseId)
    {
        await _service.QuizService.DeleteQuiz(quizId, courseId, trackChanges: false);
        return NoContent();
    }
  


}