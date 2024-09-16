using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Course
{
    public Guid CourseId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Credits { get; set; }
    [ForeignKey(nameof(Instructor))]
    public Guid InstructorId { get; set; }
    public Instructor? Instructor { get; set; }
    public  ICollection<Module> Modules { get; set; }
    public  ICollection<StudentCourse> StudentCourses { get; set; }
    public  ICollection<Certificate> Certificates { get; set; }

    public Course()
    {
        Modules = [];
        StudentCourses = [];
        Certificates = [];
    }

}