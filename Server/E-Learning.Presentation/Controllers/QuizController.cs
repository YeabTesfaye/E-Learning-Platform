using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace E_Learning.Presentation.Controllers;
[Route("/api/course/{courseId}/quiz")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IServiceManager _service;
    public QuizController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetQuizzesForCourse([FromRoute] Guid courseId)
    {
        var quizzes =await _service.QuizService.GetQuizzes(courseId, trackChanges: false);
        return Ok(quizzes);
    }

    [HttpGet("{quizId:guid}", Name = "QuizById")]
    public async Task<IActionResult> GetQuizForCourse([FromRoute] Guid courseId, [FromRoute] Guid quizId)
    {
        var quiz =await _service.QuizService.GetQuiz(quizId, courseId, trackChanges: false);
        return Ok(quiz);
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuizForCourse([FromRoute] Guid courseId, [FromBody] QuizForCreation quiz)
    {
        if (quiz is null)
            return BadRequest("QuizForCreation object is null");
        if(!ModelState.IsValid){
            return UnprocessableEntity(ModelState);
        }

        var createdQuiz =await _service.QuizService.CreateQuiz(courseId, quiz, trackChanges: false);

        return CreatedAtRoute("QuizById", new { quizId = createdQuiz.Id, courseId }, createdQuiz);
    }
    [HttpDelete("{quizId:guid}")]
    public async Task<IActionResult> DeleteQuiz([FromRoute] Guid quizId, [FromRoute] Guid courseId)
    {
        await _service.QuizService.DeleteQuiz(quizId, courseId, trackChanges: false);
        return NoContent();
    }
    [HttpPut("{quizId:guid}")]
    public async Task<IActionResult> UpdateQuiz([FromRoute] Guid quizId, [FromRoute] Guid courseId, QuizForUpdateDto quizForUpdate)
    {
        if(!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
       await _service.QuizService.UpdateQuiz(quizId, courseId, quizForUpdate, courseTrackChanges: false, quizTrackChanges: true);
        return NoContent();
    }


}