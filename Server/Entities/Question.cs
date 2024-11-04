namespace Entities;
/// <summary>
/// A many-to-one relationship between QuizQuestion and Quiz (many Questions can belong to one Quiz).
/// A one-to-many relationship between QuizQuestion and QuizAnswer (one Question can have many Answers).
/// </summary>
public class Question
{
    public Guid Id { get; set; }
    public Guid QuizId { get; set; }
    public string QuestionTitle { get; set; }

    public Quiz Quiz { get; set; }
    public ICollection<Answer> Answers { get; set; }

}