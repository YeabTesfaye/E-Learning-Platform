using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class QuizAnswerRepository : RepositoryBase<QuizAnswer>, IQuizAnswerRepository
{
    public QuizAnswerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public async Task<IEnumerable<QuizAnswer>> GetAnswersByQuestion(Guid questionId, bool trackChanges)
    {
        return await FindByCondition(qa => qa.QuestionId.Equals(questionId), trackChanges)
               .OrderBy(qa => qa.AnswerText)
               .ToListAsync();
    }

    public async Task<QuizAnswer> GetAnswerById(Guid questionId, Guid answerId, bool trackChanges)
    {
        return await FindByCondition(qa => qa.QuestionId.Equals(questionId) && qa.Id.Equals(answerId), trackChanges)
               .SingleOrDefaultAsync();
    }

    public void CreateAnswer(Guid questionId, QuizAnswer quizAnswer)
    {
        quizAnswer.QuestionId = questionId;
        Create(quizAnswer);
    }

    public void DeleteQuizAnswer(QuizAnswer quizAnswer)
    => Delete(quizAnswer);
}