using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class StudentLessonRepository : RepositoryBase<StudentLesson>, IStudentLessonRepository
{
    public StudentLessonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public async Task<IEnumerable<StudentLesson>> GetLessonsByStudent(Guid studentId, bool trackChanges)
    {
        return await FindByCondition(sl => sl.StudentId.Equals(studentId), trackChanges)
               .OrderBy(sl => sl.CompletedDatetime)
               .ToListAsync();
    }

    public async Task<StudentLesson?> StGetLesson(Guid Id, Guid studentId, Guid lessonId, bool trackChanges)
    {
        return await FindByCondition(sl => sl.StudentId.Equals(studentId) && sl.LessonId.Equals(lessonId) && sl.Id.Equals(Id), trackChanges)
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

    public async Task<StudentLesson?> GetStudentLessonByStudentId(Guid Id, Guid studentId, bool trackChanges)
    => await FindByCondition(sl => sl.Id.Equals(Id) && sl.StudentId.Equals(studentId), trackChanges)
        .SingleOrDefaultAsync();
}