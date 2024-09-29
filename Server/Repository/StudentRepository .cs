using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
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
    // Filter students based on age range if it's valid
    var students = await FindAll(trackChanges)
        .FilterStudents(studentParameters.MinAge, studentParameters.MaxAge)
        .Search(studentParameters.SearchTerm ?? string.Empty)
        .OrderBy(s => s.FirstName)
        .ToListAsync();

    // Return the students list with pagination
    return PagedList<Student>
          .ToPagedList(students, studentParameters.PageNumber, studentParameters.PageSize);
  }

  public async Task<Student?> GetStudent(Guid studentId, bool trackChanges)
  => await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
      .SingleOrDefaultAsync();
}