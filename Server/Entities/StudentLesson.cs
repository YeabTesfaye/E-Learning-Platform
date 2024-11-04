namespace Entities;
/// <summary>
/// A many-to-one relationship between StudentLesson and Student (many StudentLessons can belong to one Student).
/// A many-to-one relationship between StudentLesson and Lesson (many StudentLessons can belong to one Lesson).
/// </summary>
public class StudentLesson
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid LessonId { get; set; }
    public DateTime CompletedDatetime { get; set; }
    public bool Progress { set; get; }

    public Student Student { get; set; }
    public Lesson Lesson { get; set; }
}