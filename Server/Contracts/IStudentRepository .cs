using Entities;

namespace Contracts;

public interface IStudentRepository 
{
    IEnumerable<Student> GetAllStudenties(bool trackChanges);
}