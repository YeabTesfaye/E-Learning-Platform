using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface ILessonService
{
    IEnumerable<LessonDto> GetLessonsByModule(Guid moduleId, bool trackChanges);
    LessonDto GetLessonById(Guid lessonId, bool trackChanges);
}
