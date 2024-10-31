using Entities;
using Shared.RequestFeatures;
namespace Contracts;

public interface IStudentRepository
{
    Task<PagedList<Student>> GetAllStudents(StudentParameters studentParameters, bool trackChanges);
    Task<Student> GetStudent(Guid studentId, bool trackChanges);
    void CreatStudent(Student student);
    void DeleteStudent(Student student);
}