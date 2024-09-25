using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IStudentQuizAttemptService
{
    IEnumerable<StudentQuizAttemptDto> GetAttemptsByStudent(Guid studentId, bool trackChanges);
    StudentQuizAttemptDto GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges);
    StudentQuizAttemptDto CreateAttempt(Guid studentId, Guid quizId,
    StudentQuizAttemptForCreation studentQuizAttempt, bool trackChanges);
    void DeleteStudentQuizAttempt(Guid id, Guid studentId, bool trackChanges);
    void UpdateStudentQuizAttempt(Guid Id, Guid studentId, StudentQuizAttemptForUpdateDto studentQuizAttemptForUpdate,
    bool attemptTrackChanges, bool studentTrackChanges);
}