using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IQuizService
{
    Task<IEnumerable<QuizDto>> GetQuizzes(Guid courseId, bool trackChanges);
    Task<QuizDto> GetQuiz(Guid quizId, Guid courseId, bool trackChanges);
    Task<QuizDto> CreateQuiz(Guid courseId, QuizForCreation quiz, bool trackChanges);
    Task DeleteQuiz(Guid id, Guid courseId, bool trackChanges);
    Task UpdateQuiz(Guid id, Guid courseId, QuizForUpdateDto quizForUpdateDto, bool courseTrackChanges, bool quizTrackChanges);
}