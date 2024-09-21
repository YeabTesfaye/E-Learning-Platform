using Entities;

namespace Contracts;

public interface IQuizQuestionRepository
{
    IEnumerable<QuizQuestion> GetQuestionsByQuiz(Guid quizId, bool trackChanges);

}