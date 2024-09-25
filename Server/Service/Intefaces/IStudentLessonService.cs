using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IStudentLessonService
{
    IEnumerable<StudentLessonDto> GetLessonsByStudent(Guid studentId, bool trackChanges);
    StudentLessonDto GetLesson(Guid Id,Guid studentId, Guid lessonId, bool trackChanges);
    StudentLessonDto CreateStudentLesson(Guid studentId,Guid lessonId, StudentLessonForCreation studentLesson, bool trackChanges);
    void DeleteStudentLesson(Guid id,Guid lessonId, Guid studentId,bool trackChanges);
    void UpdateStudntLesson(Guid Id,Guid lessonId, Guid studentId,StudentLessonForUpdateDto studentLessonForUpdate,
    bool stlTrackChanges, bool stuTrackChanges, bool lessonTrackChanges);

}

