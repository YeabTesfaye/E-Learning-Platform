namespace Entities;
/// <summary>
/// A Course can have many Modules, many Quizzes, and many Enrolments.
/// The relationships are one-to-many from Course to each of these entities.
/// </summary>
public class Course
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsProgressLimited { get; set; }

    public ICollection<Module>? Modules { get; set; }
    public ICollection<Quiz>? Quizzes { get; set; }
    public ICollection<Enrolment>? Enrolments { get; set; }


}