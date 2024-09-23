using Contracts;
using Entities;

namespace Repository;

public class QuizRepository : RepositoryBase<Quiz>, IQuizRepository
{
    public QuizRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateQuizForCourse( Guid courseId, Quiz quiz)
    {
        quiz.CourseId  = courseId;
        Create(quiz);
    }

    public Quiz? GetQuiz(Guid Id, Guid courseId, bool trackChanges)
    => FindByCondition(q => q.Id.Equals(Id) && q.CourseId.Equals(courseId), trackChanges)
        .SingleOrDefault();

    public Quiz? GetQuiz(Guid Id, bool trackChanges)
    => FindByCondition(q => q.Id.Equals(Id), trackChanges)
        .SingleOrDefault();

    public IEnumerable<Quiz> GetQuizzes(Guid courseId, bool trackChanges)
    => [.. FindByCondition(q => q.CourseId.Equals(courseId), trackChanges).OrderBy(q => q.Name)];
}