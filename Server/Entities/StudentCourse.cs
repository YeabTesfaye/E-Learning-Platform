using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class StudentCourse
{
    public Guid StudentCourseId { get; set; }
    [ForeignKey(nameof(Student))]
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }
    [ForeignKey(nameof(Course))]
    public Guid CourseId { get; set; }
    public Course? Course { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public bool IsCompleted { get; set; }
}