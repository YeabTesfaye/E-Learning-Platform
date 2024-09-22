using Contracts;
using Entities;

namespace Repository;

public class StudentQuizAttemptRepository : RepositoryBase<StudentQuizAttempt>, IStudentQuizAttemptRepository
{
    public StudentQuizAttemptRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public IEnumerable<StudentQuizAttempt> GetAttemptsByStudent(Guid studentId, bool trackChanges)
    {
        return [.. FindByCondition(a => a.StudentId.Equals(studentId), trackChanges)
        .OrderBy(a => a.AttemptDatetime)];
    }
    public StudentQuizAttempt? GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges)
    {
        return FindByCondition(a => a.StudentId.Equals(studentId) && a.Id.Equals(attemptId), trackChanges)
               .SingleOrDefault();
    }
}