using Contracts;
using Entities;
using Service.Intefaces;

namespace Service.Impl;

public sealed class StudentCourseService : IStudentCourseService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public StudentCourseService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public Task CreateStudentCourseAsync(StudentCourse studentCourse)
    {
        throw new NotImplementedException();
    }

    public Task DeleteStudentCourseAsync(Guid studentCourseId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<StudentCourse>> GetAllStudentCoursesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StudentCourse> GetStudentCourseByIdAsync(Guid studentCourseId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStudentCourseAsync(StudentCourse studentCourse)
    {
        throw new NotImplementedException();
    }
}