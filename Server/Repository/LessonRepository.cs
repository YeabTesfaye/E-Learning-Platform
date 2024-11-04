using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class LessonRepository(RepositoryContext repositoryContext)
 : RepositoryBase<Lesson>(repositoryContext), ILessonRepository
{
    public void CreateLessonForMoudle(Guid moduleId, Lesson lesson)
    {
        lesson.ModuleId = moduleId;
        Create(lesson);
    }

    public void DeleteLesson(Lesson lesson)
    => Delete(lesson);

    public async Task<Lesson> GetLesson(Guid Id, Guid moduleId, bool trackChanges)
    => await FindByCondition(l => l.Id.Equals(Id) && l.ModuleId.Equals(moduleId), trackChanges)
        .SingleOrDefaultAsync();

    public async Task<Lesson> GetLesson(Guid id, bool trackChanges)
    => await FindByCondition(l => l.Id.Equals(id), trackChanges)
    .SingleOrDefaultAsync();

    public async Task<IEnumerable<Lesson>> GetLessonsByModule(Guid moduleId, bool trackChanges)
    {
        return await FindByCondition(l => l.ModuleId.Equals(moduleId), trackChanges)
               .OrderBy(l => l.Number)
               .ToListAsync();
    }


}