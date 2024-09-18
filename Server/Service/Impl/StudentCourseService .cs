using AutoMapper;
using Contracts;
using Entities;
using Service.Intefaces;
using Shared.DataTransferObjects;

namespace Service.Impl;

public sealed class StudentCourseService : IStudentCourseService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public StudentCourseService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public void CreateStudentCourse(StudentCourse studentCourse)
    {
        throw new NotImplementedException();
    }

    public void DeleteStudentCourse(Guid studentCourseId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<StudentCourseDto> GetAllStudentCourses(bool trackChanges)
    {
        try
        {
            var studentCourse = _repository.Course.GetAllCourses(trackChanges);
            var studentCoursesDto = _mapper.Map<IEnumerable<StudentCourseDto>>(studentCourse);
            return studentCoursesDto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllStudentCourses)} service method: {ex}");
            throw;

        }
    }

    public StudentCourseDto GetStudentCourseById(Guid studentCourseId)
    {
        throw new NotImplementedException();
    }

    public void UpdateStudentCourse(StudentCourse studentCourse)
    {
        throw new NotImplementedException();
    }
}