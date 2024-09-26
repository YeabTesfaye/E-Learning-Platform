using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IQuizQuestionService
{
    Task<IEnumerable<QuizQuestionDto>> GetQuestions( Guid quizId, bool trackChanges);
    Task<QuizQuestionDto> GetQuestion(Guid Id, Guid quizId, bool trackChanges);
    Task<QuizQuestionDto> CreateQuestion(Guid quizId, QuizQuestionForCreation question, bool trackChanges);
    Task DeleteQuizQuestion(Guid Id, Guid quizId,bool trackChanges);
    Task UpdateQuizQuestion(Guid Id, Guid quizId, QuizQuestionForUpdateDto quizQuestionForUpdate, bool quizTrackChanges, bool questionTrackChanges);

}