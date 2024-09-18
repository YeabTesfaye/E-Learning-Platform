using Contracts;
using Entities;

namespace Repository;

public class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
    public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Student> GetAllStudents(bool trackChanges)
    {
       return [.. FindAll(trackChanges).OrderBy(s => s.FirstName)];
    }
}