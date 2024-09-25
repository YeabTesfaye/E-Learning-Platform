using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface ICourseService
{
    IEnumerable<CourseDto> GetAllCourses(bool trackChanges);
    CourseDto GetCourse(Guid id, bool trackChanges);
    CourseDto CreateCourse(CourseForCreationDto course);
    void UpdateCourse(Guid Id, CourseForUpdateDto courseForUpdate, bool trackChanges);
    void DeleteCourse(Guid id,bool trackChanges);

}