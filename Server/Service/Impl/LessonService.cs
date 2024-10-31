using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Impl;

public class LessonService(IRepositoryManager repository, IMapper mapper) : ILessonService
{
    private readonly IRepositoryManager _repository = repository;
    private readonly IMapper _mapper = mapper;

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
        await CheckIfModuleExists(moduleId, trackChanges);

        var lessonEntity = _mapper.Map<Lesson>(lesson);
        lessonEntity.ModuleId = moduleId;
        _repository.Lesson.CreateLessonForMoudle(moduleId, lessonEntity);
        await _repository.SaveAsync();

        var lessonToReturn = _mapper.Map<LessonDto>(lessonEntity);
        return lessonToReturn;
    }

    public async Task DeleteLesson(Guid id, Guid moduleId, bool trackChanges)
    {
        await CheckIfModuleExists(moduleId, trackChanges);

        var lesson = await GetLessonAndCheckIfItExist(id, trackChanges);

        _repository.Lesson.DeleteLesson(lesson);
        await _repository.SaveAsync();
    }

    public async Task UpdateLesson(Guid Id, Guid moduleId, LessonForUpdateDto lessonForUpdate,
     bool moduleTrackChanges, bool lessonTrackChanges)
    {
        await CheckIfModuleExists(moduleId, moduleTrackChanges);

        var lessonEntity = await CheckIfLessonExistsAndReturn(Id, lessonTrackChanges);

        _mapper.Map(lessonForUpdate, lessonEntity);
        await _repository.SaveAsync();
    }
    private async Task<Lesson> CheckIfLessonExistsAndReturn(Guid Id, bool trackChanges)
    {
        var lesson = await _repository.Lesson.GetLesson(Id, trackChanges)
         ?? throw new LessonNotFounException(Id);
        return lesson;
    }
    private async Task CheckIfModuleExists(Guid moduleId, bool trackChanges)
    {
        _ = await _repository.Module.GetModule(moduleId, trackChanges)
       ?? throw new ModuleNotFoundException(moduleId);
    }
    private async Task<Lesson> GetLessonAndCheckIfItExist(
         Guid id, bool trackChanges)
    {
        var lesson = await _repository.Lesson.GetLesson(id, trackChanges)
         ?? throw new CourseNotFoundException(id);
        return lesson;
    }
}


