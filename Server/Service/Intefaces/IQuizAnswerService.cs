using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface IQuizAnswerService
{
    IEnumerable<QuizAnswerDto> GetAnswersByQuestion(Guid questionId, bool trackChanges);
    QuizAnswerDto GetAnswerById(Guid questionId, Guid answerId, bool trackChanges);
}