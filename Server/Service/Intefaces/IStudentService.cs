using Entities;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface IStudentService
{
    IEnumerable<StudentDto> GetAllStudents(bool trackChanges);
    StudentDto GetStudent(Guid id, bool trackChanges);
    StudentDto CreateStudent(StudentForCreation student);
    void UpdateStudent(Student student);
    void DeleteStudent(Guid id, bool trackChanges);
}