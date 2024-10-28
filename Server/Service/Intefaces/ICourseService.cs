using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;
using Shared.RequestFeatures;

namespace Service.Intefaces;

public interface ICourseService
{
    Task<(IEnumerable<CourseDto> courses, MetaData metaData)> GetAllCourses(CourseParameters courseParameters, bool trackChanges);
    Task<CourseDto> GetCourse(Guid id, bool trackChanges);
    Task<CourseDto> CreateCourse(CourseForCreationDto course);
    Task UpdateCourse(Guid Id, CourseForUpdateDto courseForUpdate, bool trackChanges);
    Task DeleteCourse(Guid id, bool trackChanges);

}