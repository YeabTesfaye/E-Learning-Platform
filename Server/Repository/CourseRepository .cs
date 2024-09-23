using Contracts;
using Entities;

namespace Repository;

public class CourseRepository : RepositoryBase<Course>, ICourseRepository
{
    public CourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {

    }

    public void CreateCourse(Course course)
    => Create(course);

    public IEnumerable<Course> GetAllCourses(bool trackChanges)
    {
        return [.. FindAll(trackChanges).OrderBy(c => c.Name)];
    }

    public Course? GetCourse(Guid courseId, bool trackChanges)
     => FindByCondition(c => c.Id.Equals(courseId), trackChanges)
        .SingleOrDefault();


}