using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.RequestFeatures;

namespace Service.Intefaces;

public interface IStudentService
{
    Task<(IEnumerable<StudentDto> students, MetaData metaData)> GetAllStudents( StudentParameters studentParameters, bool trackChanges);
    Task<StudentDto> GetStudent(Guid id, bool trackChanges);
    Task<StudentDto> CreateStudent(StudentForCreation studentForUpdate);
    Task DeleteStudent(Guid id, bool trackChanges);
}