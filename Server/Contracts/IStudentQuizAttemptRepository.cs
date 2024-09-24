using Entities;

namespace Contracts;

public interface IStudentQuizAttemptRepository
{
    IEnumerable<StudentQuizAttempt> GetAttemptsByStudent(Guid studentId, bool trackChanges);
    StudentQuizAttempt? GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges);

    void CreateAppempt(Guid studentId,Guid quizId, StudentQuizAttempt studentQuizAttempt);
    void DeleteAttempt(StudentQuizAttempt studentQuizAttempt);
}