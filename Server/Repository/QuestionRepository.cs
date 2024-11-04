using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class QuestionRepository(RepositoryContext repositoryContext) :
 RepositoryBase<Question>(repositoryContext), IQuestionRepository
{
    public void CreateQuizQuestion(Guid quizId, Question question)
  {
    question.QuizId = quizId;
    Create(question);
  }

  public void DeleteQuizQuestion(Question quizQuestion)
  => Delete(quizQuestion);

  public async Task<IEnumerable<Question>> GetQuestionsByQuiz(Guid quizId, bool trackChanges)
=> await FindByCondition(q => q.QuizId.Equals(quizId), trackChanges)
  .OrderBy(q => q.QuestionTitle).ToListAsync();

  public async Task<Question> GetQuizQuestion(Guid Id, Guid quizId, bool trackChanges)
    => await FindByCondition(q => q.QuizId.Equals(quizId) && q.Id.Equals(Id), trackChanges)
      .OrderBy(q => q.QuestionTitle)
      .SingleOrDefaultAsync();

  public async Task<Question> GetQuizQuestion(Guid questionId, bool trackChanges)
   => await FindByCondition(q => q.Id.Equals(questionId), trackChanges)
    .SingleOrDefaultAsync();
}