using Entities;

namespace Contracts;

public interface IQuizRepository
{
    Task<IEnumerable<Quiz>> GetQuizzes(Guid courseId, bool trackChanges);
    Task<Quiz> GetQuiz(Guid quizId, Guid courseId, bool trackChanges);
    Task<Quiz> GetQuiz(Guid Id, bool trackChanges);
    void CreateQuizForCourse(Guid courseId, Quiz quiz);
    void DeleteQuiz(Quiz quiz);

}