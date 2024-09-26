using Entities;

namespace Contracts;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudents(bool trackChanges);
    Task<Student?> GetStudent(Guid studentId, bool trackChanges);
    void CreatStudent(Student student);
    void DeleteStudent(Student student);
}