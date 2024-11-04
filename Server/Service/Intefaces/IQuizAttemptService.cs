using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IQuizAttemptService
{
    Task<IEnumerable<QuizAttemptDto>> GetAttemptsByStudent(Guid studentId, bool trackChanges);
    Task<QuizAttemptDto> GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges);
    Task<QuizAttemptDto> CreateAttempt(Guid studentId, Guid quizId,
   QuizAttemptForCreation quizAttemptForCreation, bool trackChanges);
    Task DeleteStudentQuizAttempt(Guid attemptId, Guid studentId, bool trackChanges);
    Task UpdateStudentQuizAttempt(Guid Id, Guid studentId, QuizAttemptForUpdateDto quizAttemptForUpdateDto,
    bool attemptTrackChanges, bool studentTrackChanges);
}