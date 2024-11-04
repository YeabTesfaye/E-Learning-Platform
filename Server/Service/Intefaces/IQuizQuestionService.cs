using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IQuestionService
{
    Task<IEnumerable<QuestionDto>> GetQuestions( Guid quizId, bool trackChanges);
    Task<QuestionDto> GetQuestion(Guid Id, Guid quizId, bool trackChanges);
    Task<QuestionDto> CreateQuestion(Guid quizId, QuestionForCreation questionForCreation, bool trackChanges);
    Task DeleteQuizQuestion(Guid Id, Guid quizId,bool trackChanges);
    Task UpdateQuizQuestion(Guid Id, Guid quizId, QuestionForUpdateDto questionForUpdateDto, bool quizTrackChanges, bool questionTrackChanges);

}