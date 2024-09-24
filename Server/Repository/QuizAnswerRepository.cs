using Contracts;
using Entities;

namespace Repository;

public class QuizAnswerRepository : RepositoryBase<QuizAnswer>, IQuizAnswerRepository
{
    public QuizAnswerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public IEnumerable<QuizAnswer> GetAnswersByQuestion(Guid questionId, bool trackChanges)
    {
        return FindByCondition(qa => qa.QuestionId.Equals(questionId), trackChanges)
               .OrderBy(qa => qa.AnswerText)
               .ToList();
    }

    public QuizAnswer? GetAnswerById(Guid questionId, Guid answerId, bool trackChanges)
    {
        return FindByCondition(qa => qa.QuestionId.Equals(questionId) && qa.Id.Equals(answerId), trackChanges)
               .SingleOrDefault();
    }

    public void CreateAnswer(Guid questionId, QuizAnswer quizAnswer)
    {
        quizAnswer.QuestionId = questionId;
        Create(quizAnswer);
    }

    public void DeleteQuizAnswer(QuizAnswer quizAnswer)
    => Delete(quizAnswer);
}