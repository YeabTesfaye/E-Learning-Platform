using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class QuizAttemptRepository : RepositoryBase<QuizAttempt>, IQuizAttemptRepository
{
    public QuizAttemptRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public async Task<IEnumerable<QuizAttempt>> GetAttemptsByStudent(Guid studentId, bool trackChanges)
    {
        return await FindByCondition(a => a.StudentId.Equals(studentId), trackChanges)
        .OrderBy(a => a.AttemptDatetime).ToListAsync();
    }
    public async Task<QuizAttempt> GetAttemptById(Guid attemptId, Guid studentId, bool trackChanges)
    {
        return await FindByCondition(a => a.StudentId.Equals(studentId) && a.Id.Equals(attemptId), trackChanges)
               .SingleOrDefaultAsync();
    }

    public void CreateAppempt(Guid studentId, Guid quizId, QuizAttempt studentQuizAttempt)
    {
        studentQuizAttempt.StudentId = studentId;
        studentQuizAttempt.QuizId = quizId;
        Create(studentQuizAttempt);
    }

    public void DeleteAttempt(QuizAttempt studentQuizAttempt)
    => Delete(studentQuizAttempt);
}