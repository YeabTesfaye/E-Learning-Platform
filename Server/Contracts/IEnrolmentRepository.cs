using Entities;

namespace Contracts;

public interface IEnrolmentRepository
{
    IEnumerable<Enrolment> GetEnrolments(Guid studentId, Guid courseId,bool trackChanges);
}