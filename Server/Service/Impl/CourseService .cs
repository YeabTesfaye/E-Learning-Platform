using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.RequestFeatures;

namespace Service.Impl;

public sealed class CourseService(IRepositoryManager repository, IMapper mapper) : ICourseService
{
    private readonly IRepositoryManager _repository = repository;

    private readonly IMapper _mapper = mapper;

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

 
    private async Task<Course> GetCourseAndCheckIfItExist(
         Guid id, bool trackChanges)
    {
        var employeeDb = await _repository.Course.GetCourse(id, trackChanges)
         ?? throw new CourseNotFoundException(id);
        return employeeDb;
    }
}