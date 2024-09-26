using Entities;

namespace Contracts;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllCourses(bool trackChanges);
    Task<Course?> GetCourse(Guid courseId, bool trackChanges);
    void CreateCourse(Course course);
    void DeleteCourse(Course course);


}