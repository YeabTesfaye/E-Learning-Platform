using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Impl;

public sealed class ModuleService : IModuleService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public ModuleService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<ModuleDto> CreateModuleForCourse(Guid courseId, ModuleForCreation module, bool trackChanges)
    {
        _ = await _repository.Course.GetCourse(courseId, trackChanges)
        ?? throw new CourseNotFoundException(courseId);

        var moduleEntity = _mapper.Map<Module>(module);
        _repository.Module.CreateModuleForCourse(courseId, moduleEntity);
        await _repository.SaveAsync();

        var moduleToReturn = _mapper.Map<ModuleDto>(module);
        return moduleToReturn;
    }

    public async Task DeleteModule(Guid Id, Guid courseId, bool trackChanges)
    {
        _ = await _repository.Course.GetCourse(courseId, trackChanges: false)
        ?? throw new CourseNotFoundException(courseId);
        var module = await _repository.Module.GetModule(Id, courseId, trackChanges: false)
        ?? throw new ModuleNotFoundException(courseId);
        _repository.Module.DeleteModule(module);
        await _repository.SaveAsync();
    }

    public async Task<ModuleDto> GetModule(Guid Id, Guid courseId, bool trackChanges)
    {
        _ = await _repository.Course.GetCourse(courseId, trackChanges)
         ?? throw new CourseNotFoundException(courseId);

        var module = await _repository.Module.GetModule(Id, courseId, trackChanges);
        var moduleDto = _mapper.Map<ModuleDto>(module);
        return moduleDto;
    }


    public async Task<IEnumerable<ModuleDto>> GetModules(Guid courseId, bool trackChanges)
    {
        _ = await _repository.Course.GetCourse(courseId, trackChanges)
        ?? throw new CourseNotFoundException(courseId);

        var modules = _repository.Module.GetModules(courseId, trackChanges);

        var moduleDto = _mapper.Map<IEnumerable<ModuleDto>>(modules);
        return moduleDto;
    }


    public async Task UpdateModule(Guid Id, Guid courseId, ModuleForUpdateDto moduleForUpdate, bool courseTrackChanges, bool moduleTrackChanges)
    {
        _ = await _repository.Course.GetCourse(courseId, courseTrackChanges)
         ?? throw new CourseNotFoundException(courseId);

        var moduleEntity = await _repository.Module.GetModule(Id, courseId, moduleTrackChanges)
        ?? throw new ModuleNotFoundException(Id);
        _mapper.Map(moduleForUpdate, moduleEntity);
        await _repository.SaveAsync();
    }
}