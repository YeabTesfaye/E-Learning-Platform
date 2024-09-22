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
}