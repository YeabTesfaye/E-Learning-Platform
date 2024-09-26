using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IStudentQuizAttemptService
{
    Task<IEnumerable<StudentQuizAttemptDto>> GetAttemptsByStudent(Guid studentId, bool trackChanges);
    Task<StudentQuizAttemptDto> GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges);
    Task<StudentQuizAttemptDto> CreateAttempt(Guid studentId, Guid quizId,
    StudentQuizAttemptForCreation studentQuizAttempt, bool trackChanges);
    Task DeleteStudentQuizAttempt(Guid id, Guid studentId, bool trackChanges);
    Task UpdateStudentQuizAttempt(Guid Id, Guid studentId, StudentQuizAttemptForUpdateDto studentQuizAttemptForUpdate,
    bool attemptTrackChanges, bool studentTrackChanges);
}