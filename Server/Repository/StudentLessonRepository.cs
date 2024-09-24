using Contracts;
using Entities;

namespace Repository;

public class StudentLessonRepository : RepositoryBase<StudentLesson>, IStudentLessonRepository
{
    public StudentLessonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public IEnumerable<StudentLesson> GetLessonsByStudent(Guid studentId, bool trackChanges)
    {
        return FindByCondition(sl => sl.StudentId.Equals(studentId), trackChanges)
               .OrderBy(sl => sl.CompletedDatetime)
               .ToList();
    }

    public StudentLesson? GetLessonById(Guid studentId, Guid lessonId, bool trackChanges)
    {
        return FindByCondition(sl => sl.StudentId.Equals(studentId) && sl.LessonId.Equals(lessonId), trackChanges)
               .SingleOrDefault();
    }

    public void CreateLessonForStudent(Guid studentId, Guid lessonId, StudentLesson studentLesson)
    {
        studentLesson.StudentId = studentId;
        studentLesson.LessonId = lessonId;
        Create(studentLesson);

    }

    public void DeleteStudentLesson(StudentLesson studentLesson)
    => Delete(studentLesson);

    public StudentLesson? GetStudentLessonByStudentId(Guid Id,Guid studentId, bool trackChanges)
    => FindByCondition(sl => sl.Id.Equals(Id)&&sl.StudentId.Equals(studentId), trackChanges)
        .SingleOrDefault();
}