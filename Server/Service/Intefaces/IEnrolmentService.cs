using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface IEnrolmentService
{
    IEnumerable<EnrolmentDto> GetEnrolments(Guid studentId, Guid courseId, bool trackChanges);
    EnrolmentDto GetEnrolment(Guid Id, Guid studentId, Guid courseId, bool trackChanges);
}