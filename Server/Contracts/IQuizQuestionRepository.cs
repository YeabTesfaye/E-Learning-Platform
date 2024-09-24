using Entities;

namespace Contracts;

public interface IQuizQuestionRepository
{
    IEnumerable<QuizQuestion> GetQuestionsByQuiz(Guid quizId, bool trackChanges);
    QuizQuestion? GetQuizQuestion(Guid questionId,Guid quizId, bool trackChanges);
    QuizQuestion? GetQuizQuestion(Guid questionId, bool trackChanges);
    void CreateQuizQuestion(Guid quizId,QuizQuestion question);
    void DeleteQuizQuestion(QuizQuestion quizQuestion);

}