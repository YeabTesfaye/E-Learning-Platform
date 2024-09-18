using Entities;

namespace Contracts;

public interface ICourseRepository
{
    IEnumerable<Course> GetAllCourses(bool trackChanges);

}