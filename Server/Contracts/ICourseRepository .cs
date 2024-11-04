using Entities;
using Shared.RequestFeatures;

namespace Contracts;

public interface ICourseRepository
{
    Task<PagedList<Course>> GetAllCourses(CourseParameters courseParameters, bool trackChanges);
    Task<Course> GetCourse(Guid courseId, bool trackChanges);
    void CreateCourse(Course course);
    void DeleteCourse(Course course);


}