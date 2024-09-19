namespace Entities;
/// <summary>
/// A many-to-one relationship between Lesson and Module (many Lessons can belong to one Module).
/// A one-to-many relationship between Lesson and StudentLesson (one Lesson can have many StudentLessons).
/// </summary>
public class Lesson
{
    public Guid Id { get; set; }
    public Guid ModuleId { get; set; }
    public string? Name { get; set; }
    public int Number { get; set; }
    public string? VideoUrl { get; set; }
    public string? LessonDetails { get; set; }
    public int CourseOrder { get; set; }

    public Module? Module { get; set; }
    public ICollection<StudentLesson>? StudentLessons { get; set; }
}