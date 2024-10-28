using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
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

    public async Task<EnrolmentDto> CreateEnrolment(Guid studentId, Guid courseId, EnrolmentForCreation enrolment, bool trackChanges)
    {
        _ = await _repository.Student.GetStudent(studentId, trackChanges: false)
        ?? throw new StudentNotFoundException(studentId);

        _ = await _repository.Course.GetCourse(courseId, trackChanges: false)
         ?? throw new CourseNotFoundException(courseId);

        var enrolmentEntity = _mapper.Map<Enrolment>(enrolment);
        _repository.Enrolment.CreateEnrolment(studentId, courseId, enrolmentEntity);
        await _repository.SaveAsync();

        var enrolmentToReturn = _mapper.Map<EnrolmentDto>(enrolmentEntity);
        return enrolmentToReturn;
    }

    public async Task DeleteEnrolment(Guid id, Guid studentId, Guid courseId, bool trackChanges)
    {
        _ = await _repository.Student.GetStudent(studentId, trackChanges: false)
       ?? throw new StudentNotFoundException(studentId);

        _ = await _repository.Course.GetCourse(courseId, trackChanges: false)
          ?? throw new CourseNotFoundException(courseId);

        var enrolment = await _repository.Enrolment.GetEnrolment(id, studentId, courseId, trackChanges: false)
        ?? throw new EnrolmentNotFoundException(id);

        _repository.Enrolment.DeleteEnrolment(enrolment);
        await _repository.SaveAsync();
    }

    public async Task<EnrolmentDto> GetEnrolment(Guid Id, Guid studentId, Guid courseId, bool trackChanges)
    {
        await CheckIfStudentExists(studentId, trackChanges);
        await CheckIfCourseExists(courseId, trackChanges);
       
        var enrolment = await _repository.Enrolment.GetEnrolment(Id, studentId, courseId, trackChanges);
        var enrolmentDto = _mapper.Map<EnrolmentDto>(enrolment);
        return enrolmentDto;
    }

    public async Task<IEnumerable<EnrolmentDto>> GetEnrolments(Guid studentId, Guid courseId, bool trackChanges)
    {
        await CheckIfStudentExists(studentId, trackChanges);
        await CheckIfCourseExists(courseId, trackChanges);

        var enrolments = await _repository.Enrolment.GetEnrolments(studentId, courseId, trackChanges);

        var enrolmentDto = _mapper.Map<List<EnrolmentDto>>(enrolments);
        return enrolmentDto;
    }

    public async Task UpdateEnrolment(Guid Id, Guid studentId, Guid courseId, EnrolmentForUpdateDto enrolmentForUpdate,
     bool enrolmentTrackChanges, bool studentTrackChanges, bool courseTrackChanges)
    {
        await CheckIfStudentExists(studentId, studentTrackChanges);
        await CheckIfCourseExists(courseId, courseTrackChanges);

        var enrolmentEntity = await _repository.Enrolment.GetEnrolment(Id, studentId, courseId, enrolmentTrackChanges);
        _mapper.Map(enrolmentForUpdate, enrolmentEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfStudentExists(Guid Id, bool trackChanges)
    {
        _ = await _repository.Student.GetStudent(Id, trackChanges)
        ?? throw new StudentNotFoundException(Id);
    }
    private async Task CheckIfCourseExists(Guid Id, bool trackChanges)
    {
        _ = await _repository.Course.GetCourse(Id, trackChanges)
        ?? throw new CourseNotFoundException(Id);
    }

    


}