using Contracts;
using Entities;

namespace Repository;

public class QuizAnswerRepository : RepositoryBase<QuizAnswer>, IQuizAnswerRepository
{
    public QuizAnswerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}