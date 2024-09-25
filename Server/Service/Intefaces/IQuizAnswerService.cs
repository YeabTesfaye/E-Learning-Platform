using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IQuizAnswerService
{
    IEnumerable<QuizAnswerDto> GetAnswersByQuestion(Guid questionId, bool trackChanges);
    QuizAnswerDto GetAnswerById(Guid questionId, Guid answerId, bool trackChanges);

    QuizAnswerDto CreateAnswer(Guid questionId, QuizAnswerForCreation quizAnswer, bool trackChanges);
    void DeleteQuizAnswer(Guid id, Guid questionId,bool trackChanges);
    void UpdateQuizAnswer(Guid Id, Guid questionId, QuizAnswerForUpdateDto quizAnswerForUpdate, bool questionTrackChanges, bool quizTrackChanges);
}