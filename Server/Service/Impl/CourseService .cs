using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;
using Shared.RequestFeatures;

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

    public async Task<CourseDto> CreateCourse(CourseForCreationDto course)
    {
        var courseToEntity = _mapper.Map<Course>(course);

        _repository.Course.CreateCourse(courseToEntity);
        await _repository.SaveAsync();

        var courseToReturn = _mapper.Map<CourseDto>(courseToEntity);
        return courseToReturn;
    }

    public async Task DeleteCourse(Guid id, bool trackChanges)
    {
        var course = await GetCourseAndCheckIfItExist(id, trackChanges);
        _repository.Course.DeleteCourse(course);
        await _repository.SaveAsync();
    }

    public async Task<(IEnumerable<CourseDto> courses, MetaData metaData)> GetAllCourses(CourseParameters courseParameters, bool trackChanges)
    {
        if (!courseParameters.ValidPriceRange)
        {
            throw new MaxAgeRangeBadRequestException("Max Price can't be less than min price");
        }
        var coursesWithMetadata = await _repository.Course.GetAllCourses(courseParameters, trackChanges);
        var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(coursesWithMetadata);
        return (courses: coursesDto, metaData: coursesWithMetadata.MetaData);

    }

    public async Task<CourseDto> GetCourse(Guid id, bool trackChanges)
    {
        var course = await GetCourseAndCheckIfItExist(id, trackChanges);
        var courseDto = _mapper.Map<CourseDto>(course);
        return courseDto;
    }

    public async Task UpdateCourse(Guid Id, CourseForUpdateDto courseForUpdate, bool trackChanges)
    {
        var courseEntity = await GetCourseAndCheckIfItExist(Id, trackChanges);
        _mapper.Map(courseForUpdate, courseEntity);
        await _repository.SaveAsync();
    }

    private async Task<Course> GetCourseAndCheckIfItExist(
         Guid id, bool trackChanges)
    {
        var employeeDb = await _repository.Course.GetCourse(id, trackChanges)
         ?? throw new CourseNotFoundException(id);
        return employeeDb;
    }
}