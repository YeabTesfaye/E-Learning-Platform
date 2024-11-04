using Entities;

namespace Contracts;

public interface IAnswerRepository
{
    Task<IEnumerable<Answer>> GetAnswersByQuestion(Guid questionId, bool trackChanges);
    Task<Answer> GetAnswerById(Guid answerId, Guid questionId, bool trackChanges);
    void CreateAnswer(Guid questionId, Answer quizAnswer);
    void DeleteQuizAnswer(Answer quizAnswer);
}