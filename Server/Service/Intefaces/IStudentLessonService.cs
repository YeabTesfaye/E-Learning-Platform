using Shared.DataTransferObjects;

namespace Service;

public interface IStudentLessonService
{
    IEnumerable<StudentLessonDto> GetLessonsByStudent(Guid studentId, bool trackChanges);
    StudentLessonDto GetLessonById(Guid studentId, Guid lessonId, bool trackChanges);
}