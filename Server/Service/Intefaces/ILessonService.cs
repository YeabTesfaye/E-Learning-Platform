using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface ILessonService
{
    IEnumerable<LessonDto> GetLessonsByModule(Guid moduleId, bool trackChanges);
    LessonDto GetLesson(Guid Id, Guid moduleId, bool trackChanges);
    LessonDto CreateLesson(Guid moduleId, LessonForCreation lesson, bool trackChanges);
    void DeleteLesson(Guid id, Guid moduleId, bool trackChanges);


}
