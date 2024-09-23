using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;

namespace Service.Impl;

public class LessonService : ILessonService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public LessonService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public IEnumerable<LessonDto> GetLessonsByModule(Guid moduleId, bool trackChanges)
    {
        var lessons = _repository.Lesson.GetLessonsByModule(moduleId, trackChanges);
        return _mapper.Map<IEnumerable<LessonDto>>(lessons);
    }

    public LessonDto GetLesson(Guid Id,Guid moduleId, bool trackChanges)
    {
        var lesson = _repository.Lesson.GetLesson(Id,moduleId, trackChanges) 
        ?? throw new LessonNotFounException(Id);
        return _mapper.Map<LessonDto>(lesson);
    }
}


