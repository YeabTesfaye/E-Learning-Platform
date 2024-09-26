using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface ILessonService
{
    Task<IEnumerable<LessonDto>> GetLessonsByModule(Guid moduleId, bool trackChanges);
    Task<LessonDto> GetLesson(Guid Id, Guid moduleId, bool trackChanges);
    Task<LessonDto> CreateLesson(Guid moduleId, LessonForCreation lesson, bool trackChanges);
    Task DeleteLesson(Guid Id, Guid moduleId, bool trackChanges);
    Task UpdateLesson(Guid Id,Guid moduleId,LessonForUpdateDto lessonForUpdate,bool moduleTrackChanges, bool lessonTrackChanges);


}
