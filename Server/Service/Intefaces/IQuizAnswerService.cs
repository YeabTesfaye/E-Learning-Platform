using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface IQuizAnswerService
{
    IEnumerable<QuizAnswerDto> GetAnswersByQuestion(Guid questionId, bool trackChanges);
    QuizAnswerDto GetAnswerById(Guid questionId, Guid answerId, bool trackChanges);

    QuizAnswerDto CreateAnswer(Guid questionId, QuizAnswerForCreation quizAnswer, bool trackChanges);
}