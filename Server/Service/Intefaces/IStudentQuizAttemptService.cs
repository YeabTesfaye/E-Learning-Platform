using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface IStudentQuizAttemptService
{
    IEnumerable<StudentQuizAttemptDto> GetAttemptsByStudent(Guid studentId, bool trackChanges);
    StudentQuizAttemptDto GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges);
}