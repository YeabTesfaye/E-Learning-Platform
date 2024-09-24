using Entities;

namespace Contracts;

public interface IStudentLessonRepository
{
    IEnumerable<StudentLesson> GetLessonsByStudent(Guid studentId, bool trackChanges);
    StudentLesson? GetLessonById(Guid studentId, Guid lessonId, bool trackChanges);
    StudentLesson? GetStudentLessonByStudentId(Guid Id,Guid studentId, bool trackChanges);
    void CreateLessonForStudent(Guid studentId,Guid lessonId, StudentLesson studentLesson);
    void DeleteStudentLesson(StudentLesson studentLesson);

}