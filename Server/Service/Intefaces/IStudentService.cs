using Entities;

namespace Service.Intefaces;

public interface IStudentService
{
    IEnumerable<Student> GetAllStudents(bool trackChanges);
    IEnumerable<Student> GetStudentById(Guid studentId);
    void CreateStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(Guid studentId);
}