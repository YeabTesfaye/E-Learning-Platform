using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

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

    public async Task<PagedList<Course>> GetAllCourses(CourseParameters courseParameters, bool trackChanges)
    {
        var courses = await FindAll(trackChanges).OrderBy(c => c.Name)
            .ToListAsync();
        return PagedList<Course>
                  .ToPagedList(courses, courseParameters.PageNumber, courseParameters.PageSize);
    }


    public async Task<Course?> GetCourse(Guid courseId, bool trackChanges)
     => await FindByCondition(c => c.Id.Equals(courseId), trackChanges)
        .SingleOrDefaultAsync();


}