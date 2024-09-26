using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

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

    public async Task<IEnumerable<LessonDto>> GetLessonsByModule(Guid moduleId, bool trackChanges)
    {
        var lessons = await _repository.Lesson.GetLessonsByModule(moduleId, trackChanges);
        return _mapper.Map<IEnumerable<LessonDto>>(lessons);
    }

    public async Task<LessonDto> GetLesson(Guid Id, Guid moduleId, bool trackChanges)
    {
        var lesson = await _repository.Lesson.GetLesson(Id, moduleId, trackChanges)
        ?? throw new LessonNotFounException(Id);
        return _mapper.Map<LessonDto>(lesson);
    }

    public async Task<LessonDto> CreateLesson(Guid moduleId, LessonForCreation lesson, bool trackChanges)
    {
        _ = await _repository.Module.GetModule(moduleId, trackChanges: false)
        ?? throw new ModuleNotFoundException(moduleId);

        var lessonEntity = _mapper.Map<Lesson>(lesson);
        lessonEntity.ModuleId = moduleId;
        _repository.Lesson.CreateLessonForMoudle(moduleId, lessonEntity);
        await _repository.SaveAsync();

        var lessonToReturn = _mapper.Map<LessonDto>(lessonEntity);
        return lessonToReturn;
    }

    public async Task DeleteLesson(Guid id, Guid moduleId, bool trackChanges)
    {
        _ = await _repository.Module.GetModule(moduleId, trackChanges: false)
    ?? throw new ModuleNotFoundException(moduleId);

        var lesson = await _repository.Lesson.GetLesson(id, moduleId, trackChanges: false)
         ?? throw new LessonNotFounException(id);

        _repository.Lesson.DeleteLesson(lesson);
        await _repository.SaveAsync();
    }

    public async Task UpdateLesson(Guid Id, Guid moduleId, LessonForUpdateDto lessonForUpdate,
     bool moduleTrackChanges, bool lessonTrackChanges)
    {
        _ = await _repository.Module.GetModule(moduleId, moduleTrackChanges)
        ?? throw new ModuleNotFoundException(moduleId);

        var lessonEntity = await _repository.Lesson.GetLesson(Id, lessonTrackChanges)
        ?? throw new LessonNotFounException(Id);

        _mapper.Map(lessonForUpdate, lessonEntity);
        await _repository.SaveAsync();
    }
}


