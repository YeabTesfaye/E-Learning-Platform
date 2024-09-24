using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface IQuizService
{
    IEnumerable<QuizDto> GetQuizzes(Guid courseId, bool trackChanges);
    QuizDto GetQuiz(Guid quizId, Guid courseId, bool trackChanges);
    QuizDto CreateQuiz(Guid courseId,QuizForCreation quiz, bool trackChanges);
    void DeleteQuiz(Guid id, Guid courseId, bool trackChanges);
}