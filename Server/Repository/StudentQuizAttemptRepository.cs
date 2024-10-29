using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class StudentQuizAttemptRepository : RepositoryBase<StudentQuizAttempt>, IStudentQuizAttemptRepository
{
    public StudentQuizAttemptRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public async Task<IEnumerable<StudentQuizAttempt>> GetAttemptsByStudent(Guid studentId, bool trackChanges)
    {
        return await FindByCondition(a => a.StudentId.Equals(studentId), trackChanges)
        .OrderBy(a => a.AttemptDatetime).ToListAsync();
    }
    public async Task<StudentQuizAttempt> GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges)
    {
        return await FindByCondition(a => a.StudentId.Equals(studentId) && a.Id.Equals(attemptId), trackChanges)
               .SingleOrDefaultAsync();
    }

    public void CreateAppempt(Guid studentId, Guid quizId, StudentQuizAttempt studentQuizAttempt)
    {
        studentQuizAttempt.StudentId = studentId;
        studentQuizAttempt.QuizId = quizId;
        Create(studentQuizAttempt);
    }

    public void DeleteAttempt(StudentQuizAttempt studentQuizAttempt)
    => Delete(studentQuizAttempt);
}