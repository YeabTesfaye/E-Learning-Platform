using Contracts;
using Entities;

namespace Repository;

public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
{
    public LessonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}