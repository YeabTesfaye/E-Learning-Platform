using Entities;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface ICourseService
{
    IEnumerable<CourseDto> GetAllCourses(bool trackChanges);
    CourseDto GetCourse(Guid id, bool trackChanges);
    CourseDto CreateCourse(CourseForCreationDto course);
    void UpdateCourse(Course course);
    void DeleteCourse(Guid id,bool trackChanges);

}