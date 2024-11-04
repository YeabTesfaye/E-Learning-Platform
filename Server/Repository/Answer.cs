using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
{
    public AnswerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public async Task<IEnumerable<Answer>> GetAnswersByQuestion(Guid questionId, bool trackChanges)
    {
        return await FindByCondition(qa => qa.QuestionId.Equals(questionId), trackChanges)
               .OrderBy(qa => qa.AnswerText)
               .ToListAsync();
    }

    public async Task<Answer> GetAnswerById(Guid answerId, Guid questionId, bool trackChanges)
    {
        return await FindByCondition(qa => qa.QuestionId.Equals(questionId) && qa.Id.Equals(answerId), trackChanges)
               .SingleOrDefaultAsync();
    }

    public void CreateAnswer(Guid questionId, Answer answer)
    {
        answer.QuestionId = questionId;
        Create(answer);
    }

    public void DeleteQuizAnswer(Answer answer)
    => Delete(answer);
}