using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface IStudentLessonService
{
    IEnumerable<StudentLessonDto> GetLessonsByStudent(Guid studentId, bool trackChanges);
    StudentLessonDto GetLessonById(Guid studentId, Guid lessonId, bool trackChanges);
    StudentLessonDto CreateStudentLesson(Guid studentId,Guid lessonId, StudentLessonForCreation studentLesson, bool trackChanges);
    void DeleteStudentLesson(Guid id, Guid studentId,bool trackChanges);

}