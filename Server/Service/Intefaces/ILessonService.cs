using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface ILessonService
{
    IEnumerable<LessonDto> GetLessonsByModule(Guid moduleId, bool trackChanges);
    LessonDto GetLesson(Guid Id, Guid moduleId, bool trackChanges);
    LessonDto CreateLesson(Guid moduleId, LessonForCreation lesson, bool trackChanges);
    void DeleteLesson(Guid Id, Guid moduleId, bool trackChanges);
    void UpdateLesson(Guid Id,Guid moduleId,LessonForUpdateDto lessonForUpdate,bool moduleTrackChanges, bool lessonTrackChanges);


}
