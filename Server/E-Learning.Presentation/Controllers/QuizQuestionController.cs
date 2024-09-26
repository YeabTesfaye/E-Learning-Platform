using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace E_Learning.Presentation.Controllers;

[Route("/api/quiz/{quizId}/questions")]
[ApiController]
public class QuizQuestionController : ControllerBase
{
   private readonly IServiceManager _service;

   public QuizQuestionController(IServiceManager service) => _service = service;

   [HttpGet]
   public async Task<IActionResult> GetQuestionsForQuiz(Guid quizId)
   {
      var questions =await _service.QuizQuestionService.GetQuestions(quizId, trackChanges: false);
      return Ok(questions);
   }

   [HttpGet("{questionId:guid}", Name = "QuestionById")]
   public async Task<IActionResult> GetQuestionForQuiz([FromRoute] Guid quizId, [FromRoute] Guid questionId)
   {
      var question =await _service.QuizQuestionService.GetQuestion(questionId, quizId, trackChanges: false);
      return Ok(question);
   }

   [HttpPost]
   public async Task<IActionResult> CreateQuestionForQuiz([FromRoute] Guid quizId, [FromBody] QuizQuestionForCreation quizQuestion)
   {

      if (quizQuestion is null)
         return BadRequest("QuizQuestionForCreation object is null");

      if (!ModelState.IsValid)
      {
         return UnprocessableEntity(ModelState);
      }

      var question =await _service.QuizQuestionService.CreateQuestion(quizId, quizQuestion, trackChanges: false);

      return CreatedAtRoute("QuestionById", new { quizId, questionId = question.Id }, question);
   }

   [HttpDelete("{questionId:guid}")]
   public async Task<IActionResult> DeleteQuizQuestion([FromRoute] Guid quizId, [FromRoute] Guid questionId)
   {
     await _service.QuizQuestionService.DeleteQuizQuestion(questionId, quizId, trackChanges: false);
      return NoContent();
   }
   [HttpPut("{questionId:guid}")]
   public async Task<IActionResult> UpdateQuizQuesion([FromRoute] Guid quizId, [FromRoute] Guid questionId, QuizQuestionForUpdateDto quizQuestionForUpdate)
   {
      if(!ModelState.IsValid)
         return UnprocessableEntity(ModelState);
      await _service.QuizQuestionService.UpdateQuizQuestion(questionId, quizId, quizQuestionForUpdate, quizTrackChanges: false, questionTrackChanges: true);
      return NoContent();

   }


}