using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Impl;

public sealed class ModuleService
(IRepositoryManager repository,  IMapper mapper) : IModuleService
{
    private readonly IRepositoryManager _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<ModuleDto> CreateModuleForCourse(Guid courseId, ModuleForCreation moduleForCreation, bool trackChanges)
    {
        await CheckIfCourseExists(courseId, trackChanges);
        var moduleEntity = _mapper.Map<Module>(moduleForCreation);
        _repository.Module.CreateModuleForCourse(courseId, moduleEntity);
        await _repository.SaveAsync();
        var moduleToReturn = _mapper.Map<ModuleDto>(moduleEntity);
        return moduleToReturn;
    }

    public async Task DeleteModule(Guid Id, Guid courseId, bool trackChanges)
    {
        await CheckIfCourseExists(courseId, trackChanges);
        var module = await CheckIfModuleExistsAndReturn(Id, trackChanges);
        _repository.Module.DeleteModule(module);
        await _repository.SaveAsync();
    }

    public async Task<ModuleDto> GetModule(Guid Id, Guid courseId, bool trackChanges)
    {
        await CheckIfCourseExists(courseId, trackChanges);

        var module = await _repository.Module.GetModule(Id, courseId, trackChanges);
        var moduleDto = _mapper.Map<ModuleDto>(module);
        return moduleDto;
    }


    public async Task<IEnumerable<ModuleDto>> GetModules(Guid courseId, bool trackChanges)
    {
        await CheckIfCourseExists(courseId, trackChanges);
        var modules = await _repository.Module.GetModules(courseId, trackChanges);

        var moduleDto = _mapper.Map<IEnumerable<ModuleDto>>(modules);
        return moduleDto;
    }


  
    private async Task<Module> CheckIfModuleExistsAndReturn(Guid moduleId, bool trackChanges)
    {
        var module = await _repository.Module.GetModule(moduleId, trackChanges)
       ?? throw new ModuleNotFoundException(moduleId);
        return module;
    }
    private async Task CheckIfCourseExists(Guid courseId, bool trackChanges)
    {
        _ = await _repository.Course.GetCourse(courseId, trackChanges)
        ?? throw new CourseNotFoundException(courseId);
    }

}