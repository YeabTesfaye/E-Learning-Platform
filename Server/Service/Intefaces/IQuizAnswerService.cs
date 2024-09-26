using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IQuizAnswerService
{
    Task<IEnumerable<QuizAnswerDto>> GetAnswersByQuestion(Guid questionId, bool trackChanges);
    Task<QuizAnswerDto> GetAnswerById(Guid questionId, Guid answerId, bool trackChanges);

    Task<QuizAnswerDto> CreateAnswer(Guid questionId, QuizAnswerForCreation quizAnswer, bool trackChanges);
    Task DeleteQuizAnswer(Guid id, Guid questionId, bool trackChanges);
    Task UpdateQuizAnswer(Guid Id, Guid questionId, QuizAnswerForUpdateDto quizAnswerForUpdate, bool questionTrackChanges, bool quizTrackChanges);
}