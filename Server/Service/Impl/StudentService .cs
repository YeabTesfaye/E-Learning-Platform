using Contracts;
using Entities;
using Service.Intefaces;

namespace Service.Impl;

public sealed class StudentService : IStudentService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    public StudentService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public void CreateStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public void DeleteStudent(Guid studentId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Student> GetAllStudents(bool trackChanges)
    {
        try
        {
            var studenties =
           _repository.Student.GetAllStudenties(trackChanges);
            return studenties;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllStudents)} service method {ex}");
            throw;

        }
    }

    public IEnumerable<Student> GetStudentById(Guid studentId)
    {
        throw new NotImplementedException();
    }

    public void UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }
}