namespace Entities;
/// <summary>
/// A many-to-one relationship between QuizAnswer and QuizQuestion (many Answers can belong to one Question).
/// </summary>
public class Answer
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string AnswerText { get; set; }
    public bool IsCorrect { get; set; }

    public Question Question { get; set; }
}