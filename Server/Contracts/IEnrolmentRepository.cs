using Entities;
namespace Contracts;

public interface IEnrolmentRepository
{
    Task<IEnumerable<Enrolment>> GetEnrolments(Guid studentId, Guid courseId,bool trackChanges);
    Task<Enrolment> GetEnrolment(Guid Id, Guid studentId, Guid courseId, bool trackChanges);
    void CreateEnrolment(Guid studentId, Guid courseId,Enrolment enrolment);
    void DeleteEnrolment(Enrolment enrolment);
}