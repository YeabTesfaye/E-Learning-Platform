using AutoMapper;
using Contracts;
using Entities.Exceptions;
using LoggerService;
using Service.Intefaces;
using Shared.DataTransferObjects;

namespace Service.Impl;

public class EnrolmentService : IEnrolmentService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public EnrolmentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public EnrolmentDto GetEnrolment(Guid Id, Guid studentId, Guid courseId, bool trackChanges)
    {
        _ = _repository.Student.GetStudent(studentId, trackChanges)
        ?? throw new StudentNotFoundException(studentId);
        _ = _repository.Course.GetCourse(courseId, trackChanges)
        ?? throw new CourseNotFoundException(courseId);

        var enrolment = _repository.Enrolment.GetEnrolment(Id, studentId, courseId, trackChanges);
        var enrolmentDto = _mapper.Map<EnrolmentDto>(enrolment);
        return enrolmentDto;
    }

    public IEnumerable<EnrolmentDto> GetEnrolments(Guid studentId, Guid courseId, bool trackChanges)
    {
        _ = _repository.Student.GetStudent(studentId, trackChanges)
            ?? throw new StudentNotFoundException(studentId);
        _ = _repository.Course.GetCourse(courseId, trackChanges)
            ?? throw new CourseNotFoundException(courseId);

        var enrolments = _repository.Enrolment.GetEnrolments(studentId, courseId, trackChanges);

        var enrolmentDto = _mapper.Map<List<EnrolmentDto>>(enrolments);
        return enrolmentDto;
    }



}