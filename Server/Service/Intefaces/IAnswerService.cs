using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface IAnswerService
{
    Task<IEnumerable<AnswerDto>> GetAnswersByQuestion(Guid questionId, bool trackChanges);
    Task<AnswerDto> GetAnswerById(Guid answerId, Guid questionId, bool trackChanges);

    Task<AnswerDto> CreateAnswer(Guid questionId, AnswerForCreation answerForCreation, bool trackChanges);
    Task DeleteQuizAnswer(Guid answerId, Guid questionId, bool trackChanges);
}