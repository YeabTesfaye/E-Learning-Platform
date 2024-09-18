using Entities;
using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface ICourseService
{
    IEnumerable<CourseDto> GetAllCourses(bool trackChanges);
    CourseDto GetCourseById(Guid courseId);
    void CreateCourse(Course course);
    void UpdateCourse(Course course);
    void DeleteCourse(Guid courseId);

}