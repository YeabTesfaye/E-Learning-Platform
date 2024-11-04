using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class QuizRepository : RepositoryBase<Quiz>, IQuizRepository
{
    public QuizRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateQuizForCourse(Guid courseId, Quiz quiz)
    {
        quiz.CourseId = courseId;
        Create(quiz);
    }

    public void DeleteQuiz(Quiz quiz)
    => Delete(quiz);

    public async Task<Quiz> GetQuiz(Guid quizId, Guid courseId, bool trackChanges)
    => await FindByCondition(q => q.Id.Equals(quizId) && q.CourseId.Equals(courseId), trackChanges)
        .SingleOrDefaultAsync();

    public async Task<Quiz> GetQuiz(Guid Id, bool trackChanges)
    => await FindByCondition(q => q.Id.Equals(Id), trackChanges)
        .SingleOrDefaultAsync();

    public async Task<IEnumerable<Quiz>> GetQuizzes(Guid courseId, bool trackChanges)
    => await FindByCondition(q => q.CourseId.Equals(courseId), trackChanges)
    .OrderBy(q => q.Name).ToListAsync();
}