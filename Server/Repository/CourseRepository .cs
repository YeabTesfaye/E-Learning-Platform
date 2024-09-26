using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class CourseRepository : RepositoryBase<Course>, ICourseRepository
{
    public CourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {

    }

    public void CreateCourse(Course course)
    => Create(course);

    public void DeleteCourse(Course course)
    => Delete(course);

    public async Task<IEnumerable<Course>> GetAllCourses(bool trackChanges)
    {
        return await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
    }


    public async Task<Course?> GetCourse(Guid courseId, bool trackChanges)
     => await FindByCondition(c => c.Id.Equals(courseId), trackChanges)
        .SingleOrDefaultAsync();


}