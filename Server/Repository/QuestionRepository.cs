using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class QuizQuestionRepository(RepositoryContext repositoryContext) :
 RepositoryBase<QuizQuestion>(repositoryContext), IQuizQuestionRepository
{
    public void CreateQuizQuestion(Guid quizId, QuizQuestion question)
  {
    question.QuizId = quizId;
    Create(question);
  }

  public void DeleteQuizQuestion(QuizQuestion quizQuestion)
  => Delete(quizQuestion);

  public async Task<IEnumerable<QuizQuestion>> GetQuestionsByQuiz(Guid quizId, bool trackChanges)
=> await FindByCondition(q => q.QuizId.Equals(quizId), trackChanges)
  .OrderBy(q => q.QuestionTitle).ToListAsync();

  public async Task<QuizQuestion?> GetQuizQuestion(Guid Id, Guid quizId, bool trackChanges)
    => await FindByCondition(q => q.QuizId.Equals(quizId) && q.Id.Equals(Id), trackChanges)
      .OrderBy(q => q.QuestionTitle)
      .SingleOrDefaultAsync();

  public async Task<QuizQuestion?> GetQuizQuestion(Guid questionId, bool trackChanges)
   => await FindByCondition(q => q.Id.Equals(questionId), trackChanges)
    .SingleOrDefaultAsync();
}