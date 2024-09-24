using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

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

    public CourseDto CreateCourse(CourseForCreationDto course)
    {
        var courseToEntity = _mapper.Map<Course>(course);

        _repository.Course.CreateCourse(courseToEntity);
        _repository.Save();

        var courseToReturn = _mapper.Map<CourseDto>(courseToEntity);
        return courseToReturn;
    }

    public void DeleteCourse(Guid id, bool trackChanges)
    {
        var course = _repository.Course.GetCourse(id, trackChanges: false)
        ?? throw new CourseNotFoundException(id);

        _repository.Course.DeleteCourse(course);
        _repository.Save();
    }

    public IEnumerable<CourseDto> GetAllCourses(bool trackChanges)
    {
        var courses = _repository.Course.GetAllCourses(trackChanges);
        var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(courses);
        return coursesDto;

    }

    public CourseDto GetCourse(Guid id, bool trackChanges)
    {
        var course = _repository.Course.GetCourse(id, trackChanges)
        ?? throw new CourseNotFoundException(id);
        var courseDto = _mapper.Map<CourseDto>(course);
        return courseDto;
    }

    public void UpdateCourse(Course course)
    {
        throw new NotImplementedException();
    }
}