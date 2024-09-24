using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface IStudentQuizAttemptService
{
    IEnumerable<StudentQuizAttemptDto> GetAttemptsByStudent(Guid studentId,  bool trackChanges);
    StudentQuizAttemptDto GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges);
    StudentQuizAttemptDto CreateAttempt(Guid studentId, Guid quizId,
    StudentQuizAttemptForCreation studentQuizAttempt, bool trackChanges);
}