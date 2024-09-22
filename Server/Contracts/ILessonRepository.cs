using Entities;

namespace Contracts;

public interface ILessonRepository
{
    IEnumerable<Lesson> GetLessonsByModule(Guid moduleId, bool trackChanges);
    Lesson? GetLessonById(Guid lessonId, bool trackChanges);

}