using Entities;

namespace Contracts;

public interface IQuizAnswerRepository
{
    Task<IEnumerable<QuizAnswer>> GetAnswersByQuestion(Guid questionId, bool trackChanges);
    Task<QuizAnswer?> GetAnswerById(Guid questionId, Guid answerId, bool trackChanges);
    void CreateAnswer(Guid questionId, QuizAnswer quizAnswer);
    void DeleteQuizAnswer(QuizAnswer quizAnswer);
}