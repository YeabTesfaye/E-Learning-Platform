using System.Reflection;
using Contracts;
using Service.Intefaces;

namespace Service.Impl;

public sealed class ModuleService : IModuleService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    public ModuleService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public Task CreateModuleAsync(Module module)
    {
        throw new NotImplementedException();
    }

    public Task DeleteModuleAsync(Guid moduleId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Module>> GetAllModulesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Module> GetModuleByIdAsync(Guid moduleId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateModuleAsync(Module module)
    {
        throw new NotImplementedException();
    }
}