namespace Entities;
/// <summary>
/// A one-to-many relationship between Student and Enrolment (one Student can have many Enrolments).
/// A one-to-many relationship between Student and StudentQuizAttempt (one Student can have many Quiz Attempts).
/// A one-to-many relationship between Student and StudentLesson (one Student can have many Lessons).
/// </summary>
public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public int Age { get; set; }

    public ICollection<Enrolment> Enrolments { get; set; } = [];
    public ICollection<StudentQuizAttempt> QuizAttempts { get; set; } = [];
    public ICollection<StudentLesson> StudentLessons { get; set; } = [];
}