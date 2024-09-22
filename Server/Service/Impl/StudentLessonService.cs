using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Shared.DataTransferObjects;

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

    public StudentLessonDto GetLessonById(Guid studentId, Guid lessonId, bool trackChanges)
    {
        var lesson = _repository.StudentLesson.GetLessonById(studentId, lessonId, trackChanges)
        ?? throw new LessonNotFounException(lessonId);
        return _mapper.Map<StudentLessonDto>(lesson);
    }
}