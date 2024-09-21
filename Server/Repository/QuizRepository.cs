using Contracts;
using Entities;

namespace Repository;

public class QuizRepository : RepositoryBase<Quiz>, IQuizRepository
{
    public QuizRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public Quiz? GetQuiz(Guid courseId, Guid quizId, bool trackChanges)
    => FindByCondition(q => q.CourseId.Equals(courseId) && q.Id.Equals(quizId), trackChanges)
                .SingleOrDefault();

    public IEnumerable<Quiz> GetQuizzes(Guid courseId, bool trackChanges)
    => [.. FindByCondition(q => q.CourseId.Equals(courseId), trackChanges).OrderBy(q => q.Name)];
}