using Contracts;
using Entities;
using Microsoft.Extensions.Logging;
using Service.Intefaces;

namespace Service.Impl;

public sealed class CourseService : ICourseService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public CourseService (IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public Task CreateCourseAsync(Course course)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCourseAsync(Guid courseId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Course> GetCourseByIdAsync(Guid courseId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCourseAsync(Course course)
    {
        throw new NotImplementedException();
    }
}