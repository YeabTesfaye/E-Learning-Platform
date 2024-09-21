using Contracts;
using Entities;

namespace Repository;

public class QuizQuestionRepository : RepositoryBase<QuizQuestion>, IQuizQuestionRepository
{
    public QuizQuestionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<QuizQuestion> GetQuestionsByQuiz(Guid quizId, bool trackChanges)
    => [.. FindByCondition(q => q.QuizId.Equals(quizId), trackChanges).OrderBy(q => q.QuestionTitle)];
}