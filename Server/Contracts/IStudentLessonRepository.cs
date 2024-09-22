using Entities;

namespace Contracts;

public interface IStudentLessonRepository
{
    IEnumerable<StudentLesson> GetLessonsByStudent(Guid studentId, bool trackChanges);
    StudentLesson? GetLessonById(Guid studentId, Guid lessonId, bool trackChanges);
}