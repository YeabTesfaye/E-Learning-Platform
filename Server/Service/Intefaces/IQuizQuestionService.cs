using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface IQuizQuestionService
{
    IEnumerable<QuizQuestionDto> GetQuestions( Guid quizId, bool trackChanges);
    QuizQuestionDto GetQuestion(Guid quizId, Guid quesionId, bool trackChanges);

}