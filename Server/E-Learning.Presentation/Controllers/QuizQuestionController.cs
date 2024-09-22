using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("/api/quiz/{quizId}/questions")]
[ApiController]
public class QuizQuestionController : ControllerBase
{
   private readonly IServiceManager _service;

   public QuizQuestionController(IServiceManager service) => _service = service;

   [HttpGet]
   public IActionResult GetQuestionsForQuiz(Guid quizId)
   {
      var questions = _service.QuizQuestionService.GetQuestions(quizId, trackChanges: false);
      return Ok(questions);
   }

   [HttpGet("{questionId:guid}")]
   public IActionResult GetQuestionForQuiz(Guid quizId, Guid questionId)
   {
      var question = _service.QuizQuestionService.GetQuestion(quizId, questionId, trackChanges: false);
      return Ok(question);
   }
}