namespace Entities;

/// <summary>
/// A many-to-one relationship between Enrolment and Course (many Enrolments can belong to one Course).
/// A many-to-one relationship between Enrolment and Student (many Enrolments can belong to one Student).
/// </summary>
public class Enrolment
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
    public DateTime EnrolmentDatetime { get; set; }
    public DateTime CompletedDatetime { get; set; }

    public Course Course { get; set; }
    public Student Student { get; set; }

}