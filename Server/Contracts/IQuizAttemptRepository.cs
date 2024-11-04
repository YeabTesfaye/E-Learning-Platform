using Entities;

namespace Contracts;

public interface IQuizAttemptRepository
{
    Task<IEnumerable<QuizAttempt>> GetAttemptsByStudent(Guid studentId, bool trackChanges);
    Task<QuizAttempt> GetAttemptById(Guid attemptId, Guid studentId, bool trackChanges);

    void CreateAppempt(Guid studentId, Guid quizId, QuizAttempt quizAttempt);
    void DeleteAttempt(QuizAttempt studentQuizAttempt);
}