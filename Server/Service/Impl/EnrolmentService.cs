using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using LoggerService;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

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

    public EnrolmentDto CreateEnrolment(Guid studentId, Guid courseId, EnrolmentForCreation enrolment, bool trackChanges)
    {
        _ = _repository.Student.GetStudent(studentId, trackChanges: false)
        ?? throw new StudentNotFoundException(studentId);

        _ = _repository.Course.GetCourse(courseId, trackChanges: false)
         ?? throw new CourseNotFoundException(courseId);

        var enrolmentEntity = _mapper.Map<Enrolment>(enrolment);
        _repository.Enrolment.CreateEnrolment(studentId, courseId, enrolmentEntity);
        _repository.Save();

        var enrolmentToReturn = _mapper.Map<EnrolmentDto>(enrolmentEntity);
        return enrolmentToReturn;
    }

    public void DeleteEnrolment(Guid id, Guid studentId, Guid courseId, bool trackChanges)
    {
        _ = _repository.Student.GetStudent(studentId, trackChanges: false)
       ?? throw new StudentNotFoundException(studentId);

        _ = _repository.Course.GetCourse(courseId, trackChanges: false)
          ?? throw new CourseNotFoundException(courseId);

        var enrolment = _repository.Enrolment.GetEnrolment(id, studentId, courseId, trackChanges: false)
        ?? throw new EnrolmentNotFoundException(id);

        _repository.Enrolment.DeleteEnrolment(enrolment);
        _repository.Save();
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

    public void UpdateEnrolment(Guid Id, Guid studentId, Guid courseId, EnrolmentForUpdateDto enrolmentForUpdate,
     bool enrolmentTrackChanges, bool studentTrackChanges, bool courseTrackChanges)
    {
        _ = _repository.Student.GetStudent(studentId, studentTrackChanges)
         ?? throw new StudentNotFoundException(studentId);

        _ = _repository.Course.GetCourse(courseId, courseTrackChanges)
        ?? throw new CourseNotFoundException(courseId);

        var enrolmentEntity = _repository.Enrolment.GetEnrolment(Id,studentId,courseId,enrolmentTrackChanges);
        _mapper.Map(enrolmentForUpdate,enrolmentEntity);
        _repository.Save();
    }
}