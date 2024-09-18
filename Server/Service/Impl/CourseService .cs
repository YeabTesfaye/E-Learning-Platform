using AutoMapper;
using Contracts;
using Entities;
using Microsoft.Extensions.Logging;
using Service.Intefaces;
using Shared.DataTransferObjects;

namespace Service.Impl;

public sealed class CourseService : ICourseService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CourseService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public void CreateCourse(Course course)
    {
        throw new NotImplementedException();
    }

    public void DeleteCourse(Guid courseId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CourseDto> GetAllCourses(bool trackChanges)
    {
             try
        {
            var courses = _repository.Course.GetAllCourses(trackChanges);
            var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return coursesDto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllCourses)} service method: {ex}");
            throw;

        }
    }

    public CourseDto GetCourseById(Guid courseId)
    {
        throw new NotImplementedException();
    }

    public void UpdateCourse(Course course)
    {
        throw new NotImplementedException();
    }
}