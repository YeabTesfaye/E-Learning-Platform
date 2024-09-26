using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IStudentLessonService
{
    Task<IEnumerable<StudentLessonDto>> GetLessonsByStudent(Guid studentId, bool trackChanges);
    Task<StudentLessonDto> GetLesson(Guid Id, Guid studentId, Guid lessonId, bool trackChanges);
    Task<StudentLessonDto> CreateStudentLesson(Guid studentId, Guid lessonId, StudentLessonForCreation studentLesson, bool trackChanges);
    Task DeleteStudentLesson(Guid id, Guid lessonId, Guid studentId, bool trackChanges);
    Task UpdateStudntLesson(Guid Id, Guid lessonId, Guid studentId, StudentLessonForUpdateDto studentLessonForUpdate,
    bool stlTrackChanges, bool stuTrackChanges, bool lessonTrackChanges);

}

