using Entities;

namespace Contracts;

public interface IQuizQuestionRepository
{
    IEnumerable<QuizQuestion> GetQuestionsByQuiz(Guid quizId, bool trackChanges);
    QuizQuestion? GetQuizQuestion(Guid quizId, Guid questionId, bool trackChanges);
    QuizQuestion? GetQuizQuestion(Guid questionId, bool trackChanges);
    void CreateQuizQuestion(Guid quizId,QuizQuestion question);

}