using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface IEnrolmentService
{
    IEnumerable<EnrolmentDto> GetEnrolments(Guid studentId, Guid courseId, bool trackChanges);
    EnrolmentDto GetEnrolment(Guid Id, Guid studentId, Guid courseId, bool trackChanges);
    EnrolmentDto CreateEnrolment(Guid studentId, Guid courseId, EnrolmentForCreation enrolment, bool trackChanges);
    void DeleteEnrolment(Guid id, Guid studentId, Guid courseId, bool trackChanges);
}