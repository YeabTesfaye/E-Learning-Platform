using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

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

    public ModuleDto CreateModuleForCourse(Guid courseId,ModuleForCreation module, bool trackChanges)
    {
        _ = _repository.Course.GetCourse(courseId,trackChanges) 
        ?? throw new CourseNotFoundException(courseId);

        var moduleEntity = _mapper.Map<Module>(module);
        _repository.Module.CreateModuleForCourse(courseId,moduleEntity);
        _repository.Save();

        var moduleToReturn = _mapper.Map<ModuleDto>(module);
        return moduleToReturn;
    }

    public void DeleteModule(Guid moduleId)
    {
        throw new NotImplementedException();
    }

    public ModuleDto GetModule(Guid Id, Guid courseId, bool trackChanges)
    {
        _ = _repository.Course.GetCourse(courseId, trackChanges)
         ?? throw new CourseNotFoundException(courseId);

        var module = _repository.Module.GetModule(Id,courseId,trackChanges);
         var moduleDto = _mapper.Map<ModuleDto>(module);
         return moduleDto;
    }


    public IEnumerable<ModuleDto> GetModules(Guid courseId, bool trackChanges)
    {
        _ = _repository.Course.GetCourse(courseId, trackChanges) 
        ?? throw new CourseNotFoundException(courseId);

        var modules = _repository.Module.GetModules(courseId, trackChanges);

        var moduleDto = _mapper.Map<IEnumerable<ModuleDto>>(modules);
        return moduleDto;
    }

    public void UpdateModule(Module module)
    {
        throw new NotImplementedException();
    }

    public void UpdateModule(System.Reflection.Module module)
    {
        throw new NotImplementedException();
    }
}