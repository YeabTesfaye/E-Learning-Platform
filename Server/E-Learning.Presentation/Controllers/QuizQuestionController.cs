using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

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
      return Ok();
      // var questions = _service.QuizQuestionService.GetQuestions(quizId, trackChanges: false);
      // return Ok(questions);
   }

   [HttpGet("{questionId:guid}", Name = "QuestionById")]
   public IActionResult GetQuestionForQuiz([FromRoute] Guid quizId, [FromRoute] Guid questionId)
   {
      var question = _service.QuizQuestionService.GetQuestion(quizId, questionId, trackChanges: false);
      return Ok(question);
   }

   [HttpPost]
   public IActionResult CreateQuestionForQuiz([FromRoute] Guid quizId, [FromBody] QuizQuestionForCreation quizQuestion)
   {

      if (quizQuestion is null)
         return BadRequest("QuizQuestionForCreation object is null");

      var question = _service.QuizQuestionService.CreateQuestion(quizId, quizQuestion, trackChanges: false);

      return CreatedAtRoute("QuestionById", new { quizId, questionId = question.Id }, question);
   }

   [HttpDelete("{questionId:guid}")]
   public IActionResult DeleteQuizQuestion([FromRoute] Guid quizId, [FromRoute] Guid questionId)
   {
      _service.QuizQuestionService.DeleteQuizQuestion(questionId, quizId, trackChanges: false);
      return NoContent();
   }

}