using Contracts;
using Entities;

namespace Repository;

public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
{
    public LessonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Lesson> GetLessonsByModule(Guid moduleId, bool trackChanges)
    {
        return FindByCondition(l => l.ModuleId.Equals(moduleId), trackChanges)
               .OrderBy(l => l.Number)
               .ToList();
    }

    public Lesson? GetLessonById(Guid lessonId, bool trackChanges)
    {
        return FindByCondition(l => l.Id.Equals(lessonId), trackChanges)
               .SingleOrDefault();
    }
}