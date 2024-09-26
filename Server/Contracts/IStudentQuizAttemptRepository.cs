using Entities;

namespace Contracts;

public interface IStudentQuizAttemptRepository
{
    Task<IEnumerable<StudentQuizAttempt>> GetAttemptsByStudent(Guid studentId, bool trackChanges);
    Task<StudentQuizAttempt?> GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges);

    void CreateAppempt(Guid studentId, Guid quizId, StudentQuizAttempt studentQuizAttempt);
    void DeleteAttempt(StudentQuizAttempt studentQuizAttempt);
}