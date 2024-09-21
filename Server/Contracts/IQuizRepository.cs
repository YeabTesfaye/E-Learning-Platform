using Entities;

namespace Contracts;

public interface IQuizRepository
{
    IEnumerable<Quiz> GetQuizzes(Guid courseId, bool trackChanges);
    Quiz? GetQuiz(Guid courseId, Guid quizId, bool trackChanges);
    
}