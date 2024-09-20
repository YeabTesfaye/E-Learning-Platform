using Entities;
using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface IStudentService
{
    IEnumerable<StudentDto> GetAllStudents(bool trackChanges);
    StudentDto GetStudent(Guid id, bool trackChanges);
    void CreateStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(Guid id);
}