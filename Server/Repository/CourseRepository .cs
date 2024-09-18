using Contracts;
using Entities;

namespace Repository;

public class CourseRepository : RepositoryBase<Course>, ICourseRepository
{
    public CourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    public IEnumerable<Course> GetAllCourses(bool trackChanges)
    {
        return [.. FindAll(trackChanges).OrderBy(c => c.Title)];
    }

}