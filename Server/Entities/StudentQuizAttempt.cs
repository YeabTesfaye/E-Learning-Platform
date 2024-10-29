namespace Entities;

/// <summary>
/// A many-to-one relationship between StudentQuizAttempt and Student (many Attempts can belong to one Student).
/// A many-to-one relationship between StudentQuizAttempt and Quiz (many Attempts can belong to one Quiz).
/// </summary
public class StudentQuizAttempt
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid QuizId { get; set; }
    public DateTime AttemptDatetime { get; set; }
    public int ScoreAchieved { get; set; }

    public Student Student { get; set; }
    public Quiz Quiz { get; set; }
}