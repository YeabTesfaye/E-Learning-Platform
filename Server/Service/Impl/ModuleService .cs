using System.Reflection;
using AutoMapper;
using Contracts;
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

    public IEnumerable<ModuleDto> GetAllModules(bool trackChanges)
    {
         try
        {
            var modules = _repository.Course.GetAllCourses(trackChanges);
            var modulesDto = _mapper.Map<IEnumerable<ModuleDto>>(modules);
            return modulesDto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllModules)} service method: {ex}");
            throw;

        }
    }

    public ModuleDto GetModuleById(Guid moduleId)
    {
        throw new NotImplementedException();
    }

    public void UpdateModule(Module module)
    {
        throw new NotImplementedException();
    }
}