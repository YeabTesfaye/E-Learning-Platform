using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

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

    public LessonDto GetLesson(Guid Id, Guid moduleId, bool trackChanges)
    {
        var lesson = _repository.Lesson.GetLesson(Id, moduleId, trackChanges)
        ?? throw new LessonNotFounException(Id);
        return _mapper.Map<LessonDto>(lesson);
    }

    public LessonDto CreateLesson(Guid moduleId, LessonForCreation lesson, bool trackChanges)
    {
        _ = _repository.Module.GetModule(moduleId, trackChanges: false)
        ?? throw new ModuleNotFoundException(moduleId);

        var lessonEntity = _mapper.Map<Lesson>(lesson);
        lessonEntity.ModuleId = moduleId;
        _repository.Lesson.CreateLessonForMoudle(moduleId, lessonEntity);
        _repository.Save();

        var lessonToReturn = _mapper.Map<LessonDto>(lessonEntity);
        return lessonToReturn;
    }

    public void DeleteLesson(Guid id, Guid moduleId, bool trackChanges)
    {
        _ = _repository.Module.GetModule(moduleId, trackChanges: false)
    ?? throw new ModuleNotFoundException(moduleId);

        var lesson = _repository.Lesson.GetLesson(id, moduleId, trackChanges: false)
         ?? throw new LessonNotFounException(id);

         _repository.Lesson.DeleteLesson(lesson);
         _repository.Save();
    }
}


