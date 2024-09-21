using Contracts;
using Entities;

namespace Repository;

public class EnrolmentRepository : RepositoryBase<Enrolment>, IEnrolmentRepository
{
    public EnrolmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Enrolment> GetEnrolments(Guid studentId, Guid courseId, bool trackChanges)
     => [.. FindByCondition(e => e.StudentId.Equals(studentId)&& e.CourseId.Equals(courseId),trackChanges)
     .OrderBy(e => e.EnrolmentDatetime)];
}