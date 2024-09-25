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

    public IEnumerable<StudentLessonDto> GetLessonsByStudent(Guid studentId, bool trackChanges)
    {
        var lessons = _repository.StudentLesson.GetLessonsByStudent(studentId, trackChanges);
        return _mapper.Map<IEnumerable<StudentLessonDto>>(lessons);
    }

    public StudentLessonDto GetLesson(Guid Id, Guid studentId, Guid lessonId, bool trackChanges)
    {
        var lesson = _repository.StudentLesson.StGetLesson(Id, studentId, lessonId, trackChanges)
        ?? throw new LessonNotFounException(lessonId);
        return _mapper.Map<StudentLessonDto>(lesson);
    }

    public StudentLessonDto CreateStudentLesson(Guid studentId, Guid lessonId, StudentLessonForCreation studentLesson, bool trackChanges)
    {
        _ = _repository.Student.GetStudent(studentId, trackChanges: false)
         ?? throw new StudentNotFoundException(studentId);
        _ = _repository.Lesson.GetLesson(lessonId, trackChanges: false)
        ?? throw new LessonNotFounException(lessonId);
        var studentLessonEntity = _mapper.Map<StudentLesson>(studentLesson);
        _repository.StudentLesson.CreateLessonForStudent(studentId, lessonId, studentLessonEntity);
        _repository.Save();

        var studentLessonToReturn = _mapper.Map<StudentLessonDto>(studentLessonEntity);
        return studentLessonToReturn;
    }

    public void DeleteStudentLesson(Guid id, Guid lessonId, Guid studentId, bool trackChanges)
    {
        _ = _repository.Student.GetStudent(studentId, trackChanges: false)
        ?? throw new StudentNotFoundException(studentId);

        _ = _repository.Lesson.GetLesson(lessonId, trackChanges: false)
        ?? throw new LessonNotFounException(lessonId);

        var studentLesson = _repository.StudentLesson.GetStudentLessonByStudentId(id, studentId, trackChanges: false)
         ?? throw new StudentLessonNotFound(id);
        _repository.StudentLesson.DeleteStudentLesson(studentLesson);
        _repository.Save();


    }

    public void UpdateStudntLesson(Guid Id, Guid lessonId, Guid studentId, StudentLessonForUpdateDto studentLessonForUpdate,
    bool stlTrackChanges, bool stuTrackChanges, bool lessonTrackChanges)
    {
        _ = _repository.Student.GetStudent(studentId, stuTrackChanges)
       ?? throw new StudentNotFoundException(studentId);

        _ = _repository.Lesson.GetLesson(lessonId, lessonTrackChanges)
        ?? throw new LessonNotFounException(lessonId);

        var studentLessonEntity = _repository.StudentLesson.StGetLesson(Id, studentId, lessonId, stlTrackChanges)
        ?? throw new StudentLessonNotFound(Id);

        _mapper.Map(studentLessonForUpdate, studentLessonEntity);
        _repository.Save();

    }
}