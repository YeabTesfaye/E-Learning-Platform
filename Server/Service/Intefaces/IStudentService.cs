using Entities;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IStudentService
{
    IEnumerable<StudentDto> GetAllStudents(bool trackChanges);
    StudentDto GetStudent(Guid id, bool trackChanges);
    StudentDto CreateStudent(StudentForCreation studentForUpdate);
    void UpdateStudent(Guid Id, StudentForUpdateDto student,bool trackChanges);
    void DeleteStudent(Guid id, bool trackChanges);
}