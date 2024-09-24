using Entities;

namespace Contracts;

public interface IQuizRepository
{
    IEnumerable<Quiz> GetQuizzes(Guid courseId, bool trackChanges);
    Quiz? GetQuiz(Guid Id, Guid courseId, bool trackChanges);
    Quiz? GetQuiz(Guid Id, bool trackChanges);
    void CreateQuizForCourse(Guid courseId, Quiz quiz);
    void DeleteQuiz(Quiz quiz);

}