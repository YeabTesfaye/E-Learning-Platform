namespace Entities;

/// <summary>
/// A many-to-one relationship between Quiz and Course (many Quizzes can belong to one Course).
/// A one-to-many relationship between Quiz and QuizQuestion (one Quiz can have many Questions).
/// A one-to-many relationship between Quiz and StudentQuizAttempt (one Quiz can have many Student Attempts).
/// </summary>
public class Quiz
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }
    public int CourseOrder { get; set; }
    public int MinPassScore { get; set; }
    public bool IsPassRequired { get; set; }

    public Course Course { get; set; }
    public ICollection<QuizQuestion> Questions { get; set; }
    public ICollection<StudentQuizAttempt> Attempts { get; set; }

}