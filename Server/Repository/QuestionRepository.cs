using Contracts;
using Entities;

namespace Repository;

public class QuizQuestionRepository : RepositoryBase<QuizQuestion>, IQuizQuestionRepository
{
  public QuizQuestionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
  {
  }

  public void CreateQuizQuestion(Guid quizId, QuizQuestion question)
  {
    question.QuizId = quizId;
    Create(question);
  }

    public void DeleteQuizQuestion(QuizQuestion quizQuestion)
    => Delete(quizQuestion);

    public IEnumerable<QuizQuestion> GetQuestionsByQuiz(Guid quizId, bool trackChanges)
  => [.. FindByCondition(q => q.QuizId.Equals(quizId), trackChanges).OrderBy(q => q.QuestionTitle)];

  public QuizQuestion? GetQuizQuestion( Guid questionId,Guid quizId, bool trackChanges)
    => FindByCondition(q => q.QuizId.Equals(quizId) && q.Id.Equals(questionId), trackChanges)
      .OrderBy(q => q.QuestionTitle)
      .SingleOrDefault();

  public QuizQuestion? GetQuizQuestion(Guid questionId, bool trackChanges)
   => FindByCondition(q => q.Id.Equals(questionId), trackChanges)
    .SingleOrDefault();
}