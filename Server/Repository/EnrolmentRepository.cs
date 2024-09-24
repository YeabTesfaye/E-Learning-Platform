using Contracts;
using Entities;

namespace Repository;

public class EnrolmentRepository : RepositoryBase<Enrolment>, IEnrolmentRepository
{
    public EnrolmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateEnrolment(Guid studentId, Guid courseId, Enrolment enrolment)
    {
        enrolment.StudentId = studentId;
        enrolment.CourseId = courseId;
        Create(enrolment);
    }

    public void DeleteEnrolment(Enrolment enrolment)
    => Delete(enrolment);

    public Enrolment? GetEnrolment(Guid Id, Guid studentId, Guid courseId, bool trackChanges)
    => FindByCondition(e => e.Id.Equals(Id) && e.StudentId.Equals(studentId) && e.CourseId.Equals(courseId), trackChanges)
        .SingleOrDefault();

    public IEnumerable<Enrolment> GetEnrolments(Guid studentId, Guid courseId, bool trackChanges)
     => [.. FindByCondition(e => e.StudentId.Equals(studentId)&& e.CourseId.Equals(courseId),trackChanges)
     .OrderBy(e => e.EnrolmentDatetime)];
}