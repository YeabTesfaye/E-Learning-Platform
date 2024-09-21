using System.Reflection;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;

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

    public void CreateModule(Module module)
    {
        throw new NotImplementedException();
    }

    public void DeleteModule(Guid moduleId)
    {
        throw new NotImplementedException();
    }


    public ModuleDto GetModuleById(Guid moduleId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ModuleDto> GetModules(Guid courseId, bool trackChanges)
    {
        var course = _repository.Course.GetCourse(courseId, trackChanges) 
        ?? throw new CourseNotFoundException(courseId);

        var modules = _repository.Module.GetModules(courseId, trackChanges);

        var moduleDto = _mapper.Map<IEnumerable<ModuleDto>>(modules);
        return moduleDto;
    }

    public void UpdateModule(Module module)
    {
        throw new NotImplementedException();
    }
}