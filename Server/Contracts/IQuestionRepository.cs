using Entities;

namespace Contracts;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> GetQuestionsByQuiz(Guid quizId, bool trackChanges);
    Task<Question> GetQuizQuestion(Guid Id, Guid quizId, bool trackChanges);
    Task<Question> GetQuizQuestion(Guid questionId, bool trackChanges);
    void CreateQuizQuestion(Guid quizId, Question question);
    void DeleteQuizQuestion(Question question);

}