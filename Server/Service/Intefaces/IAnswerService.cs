using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IAnswerService
{
    Task<IEnumerable<AnswerDto>> GetAnswersByQuestion(Guid questionId, bool trackChanges);
    Task<AnswerDto> GetAnswerById(Guid answerId, Guid questionId, bool trackChanges);

    Task<AnswerDto> CreateAnswer(Guid questionId, AnswerForCreation answerForCreation, bool trackChanges);
    Task DeleteQuizAnswer(Guid answerId, Guid questionId, bool trackChanges);
    Task UpdateQuizAnswer(Guid Id, Guid questionId, AnswerForUpdateDto answerForUpdateDto, bool questionTrackChanges, bool quizTrackChanges);
}