using Entities;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudents(bool trackChanges);
    Task<StudentDto> GetStudent(Guid id, bool trackChanges);
    Task<StudentDto> CreateStudent(StudentForCreation studentForUpdate);
    Task UpdateStudent(Guid Id, StudentForUpdateDto student, bool trackChanges);
    Task DeleteStudent(Guid id, bool trackChanges);
}