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

    public IEnumerable<LessonDto> GetLessons(Guid moduleId, bool trackChanges)
    {
        _ = _repository.Module.GetModules(moduleId, trackChanges)
        ?? throw new ModuleNotFoundException(moduleId);

        var lessons = _repository.Lesson.GetLessons(moduleId, trackChanges);
        var lessonsDto = _mapper.Map<IEnumerable<LessonDto>>(lessons);
        return lessonsDto;
    }
}


