using Contracts;
using Entities;

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

    public IEnumerable<Student> GetAllStudents(bool trackChanges)
    {
        return [.. FindAll(trackChanges).OrderBy(s => s.FirstName)];
    }

    public Student? GetStudent(Guid studentId, bool trackChanges)
    => FindByCondition(s => s.Id.Equals(studentId), trackChanges)
        .SingleOrDefault();
}