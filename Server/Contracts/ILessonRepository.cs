using Entities;

namespace Contracts;

public interface ILessonRepository
{
    Task<IEnumerable<Lesson>> GetLessonsByModule(Guid moduleId, bool trackChanges);
    Task<Lesson> GetLesson(Guid id, Guid moduleId, bool trackChanges);
    Task<Lesson> GetLesson(Guid id, bool trackChanges);
    void CreateLessonForMoudle(Guid moduleId, Lesson lesson);
    void DeleteLesson(Lesson lesson);
}