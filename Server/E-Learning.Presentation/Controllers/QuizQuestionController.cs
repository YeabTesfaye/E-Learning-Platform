using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("/api/course/{courseId}/quiz/{quizId}/quizQuestion")]
[ApiController]
public class QuizQuestionController : ControllerBase
{
   private readonly IServiceManager _service;

   public QuizQuestionController(IServiceManager service) => _service = service;

   [HttpGet]
   public IActionResult GetQuestionsForQuiz(Guid courseId, Guid quizId)
   {
      var questions = _service.QuizQuestionService.GetQuestions(courseId, quizId, trackChanges: false);
      return Ok(questions);
   }
}