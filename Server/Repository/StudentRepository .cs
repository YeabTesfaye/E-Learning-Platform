using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
    public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreatStudent(Student student)
    => Create(student);

    public void DeleteStudent(Student student)
    => Delete(student);

    public async Task<IEnumerable<Student>> GetAllStudents(bool trackChanges)
      => await FindAll(trackChanges).OrderBy(s => s.FirstName).ToListAsync();

    public async Task<Student?> GetStudent(Guid studentId, bool trackChanges)
    => await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
        .SingleOrDefaultAsync();
}