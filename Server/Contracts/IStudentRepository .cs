using Entities;

namespace Contracts;

public interface IStudentRepository
{
    IEnumerable<Student> GetAllStudents(bool trackChanges);
    Student? GetStudent(Guid studentId, bool trackChanges);
    void CreatStudent(Student student);
    void DeleteStudent(Student student);
}