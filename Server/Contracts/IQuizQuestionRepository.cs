using Entities;

namespace Contracts;

public interface IQuizQuestionRepository
{
    Task<IEnumerable<QuizQuestion>> GetQuestionsByQuiz(Guid quizId, bool trackChanges);
    Task<QuizQuestion> GetQuizQuestion(Guid Id, Guid quizId, bool trackChanges);
    Task<QuizQuestion> GetQuizQuestion(Guid questionId, bool trackChanges);
    void CreateQuizQuestion(Guid quizId, QuizQuestion question);
    void DeleteQuizQuestion(QuizQuestion quizQuestion);

}