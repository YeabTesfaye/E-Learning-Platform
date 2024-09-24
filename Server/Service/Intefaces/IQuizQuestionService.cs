using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface IQuizQuestionService
{
    IEnumerable<QuizQuestionDto> GetQuestions( Guid quizId, bool trackChanges);
    QuizQuestionDto GetQuestion(Guid quizId, Guid quesionId, bool trackChanges);

    QuizQuestionDto CreateQuestion(Guid quizId, QuizQuestionForCreation question, bool trackChanges);
    void DeleteQuizQuestion(Guid Id, Guid quizId,bool trackChanges);

}