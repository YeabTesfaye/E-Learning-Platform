using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IQuizService
{
    IEnumerable<QuizDto> GetQuizzes(Guid courseId, bool trackChanges);
    QuizDto GetQuiz(Guid quizId, Guid courseId, bool trackChanges);
    QuizDto CreateQuiz(Guid courseId, QuizForCreation quiz, bool trackChanges);
    void DeleteQuiz(Guid id, Guid courseId, bool trackChanges);
    void UpdateQuiz(Guid id, Guid courseId, QuizForUpdateDto quizForUpdateDto, bool courseTrackChanges, bool quizTrackChanges);
}