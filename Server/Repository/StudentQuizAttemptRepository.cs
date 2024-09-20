using Contracts;
using Entities;

namespace Repository;

public class StudentQuizAttemptRepository : RepositoryBase<StudentQuizAttempt>, IStudentQuizAttemptRepository
{
    public StudentQuizAttemptRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}