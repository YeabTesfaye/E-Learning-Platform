using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface IStudentLessonService
{
    Task<IEnumerable<StudentLessonDto>> GetLessonsByStudent(Guid studentId, Guid lessonId, bool trackChanges);
    Task<StudentLessonDto> GetStudentLesson(Guid stlessonId, Guid lessonId, Guid studentId, bool trackChanges);
    Task<StudentLessonDto> CreateStudentLesson(Guid studentId, Guid lessonId, StudentLessonForCreation studentLesson, bool trackChanges);
    Task DeleteStudentLesson(Guid stlessonId, Guid lessonId, Guid studentId, bool trackChanges);


}

