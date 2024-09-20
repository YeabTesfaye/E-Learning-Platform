using Contracts;
using Entities;

namespace Repository;

public class QuizRepository : RepositoryBase<Quiz>, IQuizRepository
{
    public QuizRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}