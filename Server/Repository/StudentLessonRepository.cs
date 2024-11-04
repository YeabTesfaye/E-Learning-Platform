using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class StudentLessonRepository(RepositoryContext repositoryContext) : RepositoryBase<StudentLesson>(repositoryContext), IStudentLessonRepository
{
    public async Task<IEnumerable<StudentLesson>> GetLessonsByStudent(Guid studentId, Guid lessonId, bool trackChanges)
    {
        return await FindByCondition(sl => sl.StudentId.Equals(studentId) && sl.LessonId.Equals(lessonId), trackChanges)
               .OrderBy(sl => sl.CompletedDatetime)
               .ToListAsync();
    }

    public async Task<StudentLesson> StGetLesson(Guid stlessonId, Guid studentId, Guid lessonId, bool trackChanges)
    {
        return await FindByCondition(sl => sl.Id.Equals(stlessonId) && sl.StudentId.Equals(studentId) && sl.LessonId.Equals(lessonId), trackChanges)
        .SingleOrDefaultAsync();

    }

    public void CreateLessonForStudent(Guid studentId, Guid lessonId, StudentLesson studentLesson)
    {
        studentLesson.StudentId = studentId;
        studentLesson.LessonId = lessonId;
        Create(studentLesson);

    }

    public void DeleteStudentLesson(StudentLesson studentLesson)
    => Delete(studentLesson);

    public async Task<StudentLesson> GetStudentLessonByStudentId(Guid Id, Guid studentId, bool trackChanges)
    => await FindByCondition(sl => sl.Id.Equals(Id) && sl.StudentId.Equals(studentId), trackChanges)
        .SingleOrDefaultAsync();
}