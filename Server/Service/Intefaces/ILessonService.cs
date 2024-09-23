using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface ILessonService
{
    IEnumerable<LessonDto> GetLessonsByModule(Guid moduleId, bool trackChanges);
    LessonDto GetLesson(Guid Id,Guid moduleId, bool trackChanges);
}
