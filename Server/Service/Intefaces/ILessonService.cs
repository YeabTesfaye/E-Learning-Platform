using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface ILessonService
{
    IEnumerable<LessonDto> GetLessons(Guid moduleId, bool trackChanges);
}
