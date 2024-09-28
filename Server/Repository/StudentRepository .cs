using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

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

  public async Task<PagedList<Student>> GetAllStudents(StudentParameters studentParameters, bool trackChanges)
  {
    var studentes = await FindAll(trackChanges).OrderBy(s => s.FirstName)
  .ToListAsync();

    return PagedList<Student>
          .ToPagedList(studentes, studentParameters.PageNumber, studentParameters.PageSize);
  }
  public async Task<Student?> GetStudent(Guid studentId, bool trackChanges)
  => await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
      .SingleOrDefaultAsync();
}