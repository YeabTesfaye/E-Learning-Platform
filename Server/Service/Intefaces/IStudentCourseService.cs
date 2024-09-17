using Entities;

namespace Service.Intefaces;

public interface IStudentCourseService
{
    Task<IEnumerable<StudentCourse>> GetAllStudentCoursesAsync();
    Task<StudentCourse> GetStudentCourseByIdAsync(Guid studentCourseId);
    Task CreateStudentCourseAsync(StudentCourse studentCourse);
    Task UpdateStudentCourseAsync(StudentCourse studentCourse);
    Task DeleteStudentCourseAsync(Guid studentCourseId);
}