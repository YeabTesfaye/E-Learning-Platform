using Shared.DataTransferObjects;
using Shared.DtoForCreation;


namespace Service.Intefaces;

public interface IEnrolmentService
{
    Task<IEnumerable<EnrolmentDto>> GetEnrolments(Guid studentId, Guid courseId, bool trackChanges);
    Task<EnrolmentDto> GetEnrolment(Guid Id, Guid studentId, Guid courseId, bool trackChanges);
    Task<EnrolmentDto> CreateEnrolment(Guid studentId, Guid courseId, EnrolmentForCreation enrolment, bool trackChanges);
    Task DeleteEnrolment(Guid id, Guid studentId, Guid courseId, bool trackChanges);
    
}