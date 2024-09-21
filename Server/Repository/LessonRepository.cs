using Contracts;
using Entities;

namespace Repository;

public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
{
    public LessonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Lesson> GetLessons(Guid moduleId, bool trackChanges)
     => [.. FindByCondition(l => l.ModuleId.Equals(moduleId), trackChanges)];
}