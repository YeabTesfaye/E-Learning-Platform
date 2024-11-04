namespace Entities;

/// <summary>
/// A many-to-one relationship between Module and Course (many Modules can belong to one Course).
/// A one-to-many relationship between Module and Lesson (one Module can have many Lessons).
/// </summary>
public class Module
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public Guid CourseId { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }

    public Course Course { get; set; }

    public ICollection<Lesson> Lessons { get; set; }
}