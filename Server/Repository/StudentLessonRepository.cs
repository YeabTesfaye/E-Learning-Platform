using Contracts;
using Entities;

namespace Repository;

public class StudentLessonRepository : RepositoryBase<StudentLesson>, IStudentLessonRepository
{
    public StudentLessonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}