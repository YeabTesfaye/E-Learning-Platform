using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IQuizQuestionService
{
    IEnumerable<QuizQuestionDto> GetQuestions( Guid quizId, bool trackChanges);
    QuizQuestionDto GetQuestion(Guid Id, Guid quizId, bool trackChanges);
    QuizQuestionDto CreateQuestion(Guid quizId, QuizQuestionForCreation question, bool trackChanges);
    void DeleteQuizQuestion(Guid Id, Guid quizId,bool trackChanges);
    void UpdateQuizQuestion(Guid Id, Guid quizId, QuizQuestionForUpdateDto quizQuestionForUpdate, bool quizTrackChanges, bool questionTrackChanges);

}