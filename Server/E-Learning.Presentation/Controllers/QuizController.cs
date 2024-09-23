using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

namespace E_Learning.Presentation.Controllers;
[Route("/api/course/{courseId}/quiz")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IServiceManager _service;
    public QuizController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetQuizzesForCourse([FromRoute] Guid courseId)
    {
        var quizzes = _service.QuizService.GetQuizzes(courseId, trackChanges: false);
        return Ok(quizzes);
    }

    [HttpGet("{quizId:guid}", Name = "QuizById")]
    public IActionResult GetQuizForCourse([FromRoute] Guid courseId,[FromRoute] Guid quizId)
    {
        var quiz = _service.QuizService.GetQuiz(quizId, courseId, trackChanges: false);
        return Ok(quiz);
    }

    [HttpPost]
    public IActionResult CreateQuizForCourse([FromRoute] Guid courseId, [FromBody] QuizForCreation quiz)
    {
        if (quiz is null)
            return BadRequest("QuizForCreation object is null");

        var createdQuiz = _service.QuizService.CreateQuiz(courseId, quiz, trackChanges: false);

        return CreatedAtRoute("QuizById", new { quizId = createdQuiz.Id, courseId }, createdQuiz);
    }

}