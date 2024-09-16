namespace Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public ICollection<StudentCourse> EnrolledCourses { get; set; }

        public Student()
        {
            EnrolledCourses = [];
        }
    }
}