using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface IQuestionService
{
    Task<IEnumerable<QuestionDto>> GetQuestions( Guid quizId, bool trackChanges);
    Task<QuestionDto> GetQuestion(Guid Id, Guid quizId, bool trackChanges);
    Task<QuestionDto> CreateQuestion(Guid quizId, QuestionForCreation questionForCreation, bool trackChanges);
    Task DeleteQuizQuestion(Guid Id, Guid quizId,bool trackChanges);

}