using Entities;
using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface IStudentCourseService
{
    IEnumerable<StudentCourseDto> GetAllStudentCourses(bool trackChanges);
    StudentCourseDto GetStudentCourseById(Guid studentCourseId);
    void CreateStudentCourse(StudentCourse studentCourse);
    void UpdateStudentCourse(StudentCourse studentCourse);
    void DeleteStudentCourse(Guid studentCourseId);
}