using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;


namespace Service.Impl;

public class StudentLessonService : IStudentLessonService
{
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;
    private readonly IRepositoryManager _repository;

    public StudentLessonService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _mapper = mapper;
        _logger = logger;
        _repository = repository;
    }

    public async Task<IEnumerable<StudentLessonDto>> GetLessonsByStudent(Guid studentId, bool trackChanges)
    {
        var lessons = await _repository.StudentLesson.GetLessonsByStudent(studentId, trackChanges);
        return _mapper.Map<IEnumerable<StudentLessonDto>>(lessons);
    }

    public async Task<StudentLessonDto> GetLesson(Guid Id, Guid studentId, Guid lessonId, bool trackChanges)
    {
        var lesson = await _repository.StudentLesson.StGetLesson(Id, studentId, lessonId, trackChanges)
        ?? throw new LessonNotFounException(lessonId);
        return _mapper.Map<StudentLessonDto>(lesson);
    }

    public async Task<StudentLessonDto> CreateStudentLesson(Guid studentId, Guid lessonId, StudentLessonForCreation studentLesson, bool trackChanges)
    {
        _ = await _repository.Student.GetStudent(studentId, trackChanges: false)
         ?? throw new StudentNotFoundException(studentId);
        _ = await _repository.Lesson.GetLesson(lessonId, trackChanges: false)
        ?? throw new LessonNotFounException(lessonId);
        var studentLessonEntity = _mapper.Map<StudentLesson>(studentLesson);
        _repository.StudentLesson.CreateLessonForStudent(studentId, lessonId, studentLessonEntity);
        await _repository.SaveAsync();

        var studentLessonToReturn = _mapper.Map<StudentLessonDto>(studentLessonEntity);
        return studentLessonToReturn;
    }

    public async Task DeleteStudentLesson(Guid id, Guid lessonId, Guid studentId, bool trackChanges)
    {
        _ = await _repository.Student.GetStudent(studentId, trackChanges: false)
        ?? throw new StudentNotFoundException(studentId);

        _ = await _repository.Lesson.GetLesson(lessonId, trackChanges: false)
        ?? throw new LessonNotFounException(lessonId);

        var studentLesson = await _repository.StudentLesson.GetStudentLessonByStudentId(id, studentId, trackChanges: false)
         ?? throw new StudentLessonNotFound(id);
        _repository.StudentLesson.DeleteStudentLesson(studentLesson);
        await _repository.SaveAsync();

    }

    public async Task UpdateStudntLesson(Guid Id, Guid lessonId, Guid studentId, StudentLessonForUpdateDto studentLessonForUpdate,
    bool stlTrackChanges, bool stuTrackChanges, bool lessonTrackChanges)
    {
        _ = await _repository.Student.GetStudent(studentId, stuTrackChanges)
       ?? throw new StudentNotFoundException(studentId);

        _ = await _repository.Lesson.GetLesson(lessonId, lessonTrackChanges)
        ?? throw new LessonNotFounException(lessonId);

        var studentLessonEntity = await _repository.StudentLesson.StGetLesson(Id, studentId, lessonId, stlTrackChanges)
        ?? throw new StudentLessonNotFound(Id);

        _mapper.Map(studentLessonForUpdate, studentLessonEntity);
        await _repository.SaveAsync();
    }
}