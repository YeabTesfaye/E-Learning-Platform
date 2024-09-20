using Contracts;
using Entities;

namespace Repository;

public class QuizQuestionRepository : RepositoryBase<QuizQuestion>, IQuizQuestionRepository
{
    public QuizQuestionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}