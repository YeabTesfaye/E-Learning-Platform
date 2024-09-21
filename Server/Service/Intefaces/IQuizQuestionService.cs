using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface IQuizQuestionService
{
    IEnumerable<QuizQuestionDto> GetQuestions(Guid courseId, Guid quizId, bool trackChanges);

}