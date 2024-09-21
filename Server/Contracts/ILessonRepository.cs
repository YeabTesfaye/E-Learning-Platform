using Entities;

namespace Contracts;

public interface ILessonRepository
{
    IEnumerable<Lesson> GetLessons(Guid moduleId, bool trackChanges);

}