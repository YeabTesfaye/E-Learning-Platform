using Contracts;
using Entities;

namespace Repository;

public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
{
    public LessonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateLessonForMoudle(Guid moduleId, Lesson lesson)
    {
        lesson.ModuleId = moduleId;
        Create(lesson);
    }

    public void DeleteLesson(Lesson lesson)
    => Delete(lesson);

    public Lesson? GetLesson(Guid Id, Guid moduleId, bool trackChanges)
    => FindByCondition(l => l.Id.Equals(Id) && l.ModuleId.Equals(moduleId), trackChanges)
        .SingleOrDefault();

    public Lesson? GetLesson(Guid id, bool trackChanges)
    => FindByCondition(l => l.Id.Equals(id), trackChanges)
    .SingleOrDefault();

    public IEnumerable<Lesson> GetLessonsByModule(Guid moduleId, bool trackChanges)
    {
        return FindByCondition(l => l.ModuleId.Equals(moduleId), trackChanges)
               .OrderBy(l => l.Number)
               .ToList();
    }


}