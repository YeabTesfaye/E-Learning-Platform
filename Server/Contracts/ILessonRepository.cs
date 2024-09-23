using Entities;

namespace Contracts;

public interface ILessonRepository
{
    IEnumerable<Lesson> GetLessonsByModule(Guid moduleId, bool trackChanges);
    Lesson? GetLesson(Guid id, Guid moduleId, bool trackChanges);
}