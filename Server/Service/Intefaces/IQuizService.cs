using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface IQuizService
{
    IEnumerable<QuizDto> GetQuizzes(Guid courseId, bool trackChanges);
    QuizDto GetQuiz(Guid courseId, Guid quizId, bool trackChanges);
    
}