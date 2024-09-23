using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;
[Route("/api/course/{courseId}/quiz")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IServiceManager _service;
    public QuizController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetQuizzesForCourse(Guid courseId)
    {
        var quizzes = _service.QuizService.GetQuizzes(courseId, trackChanges: false);
        return Ok(quizzes);
    }

    [HttpGet("{quizId:guid}", Name ="QuizById")]
    public IActionResult GetQuizForCourse ([FromRoute] Guid courseId,[FromRoute] Guid quizId)
    {
        var quiz = _service.QuizService.GetQuiz(courseId, quizId,trackChanges: false);
        return Ok(quiz);
    }
}