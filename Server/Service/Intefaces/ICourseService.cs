using Entities;
using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface ICourseService
{
    IEnumerable<CourseDto> GetAllCourses(bool trackChanges);
    CourseDto GetCourse(Guid id, bool trackChanges);
    void CreateCourse(Course course);
    void UpdateCourse(Course course);
    void DeleteCourse(Guid id);

}