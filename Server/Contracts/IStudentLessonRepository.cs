using Entities;

namespace Contracts;

public interface IStudentLessonRepository
{
    Task<IEnumerable<StudentLesson>> GetLessonsByStudent(Guid studentId,Guid lessonId, bool trackChanges);
    Task<StudentLesson> StGetLesson(Guid stlessonId, Guid studentId, Guid lessonId, bool trackChanges);
    Task<StudentLesson> GetStudentLessonByStudentId(Guid Id, Guid studentId, bool trackChanges);
    void CreateLessonForStudent(Guid studentId, Guid lessonId, StudentLesson studentLesson);
    void DeleteStudentLesson(StudentLesson studentLesson);

}