using Entities;
namespace Contracts;

public interface IEnrolmentRepository
{
    IEnumerable<Enrolment> GetEnrolments(Guid studentId, Guid courseId,bool trackChanges);
    Enrolment? GetEnrolment(Guid Id, Guid studentId, Guid courseId, bool trackChanges);
    void CreateEnrolment(Guid studentId, Guid courseId,Enrolment enrolment);
    void DeleteEnrolment(Enrolment enrolment);
}