using System.Reflection;

namespace Service.Intefaces;

public interface IModuleService
{
    Task<IEnumerable<Module>> GetAllModulesAsync();
    Task<Module> GetModuleByIdAsync(Guid moduleId);
    Task CreateModuleAsync(Module module);
    Task UpdateModuleAsync(Module module);
    Task DeleteModuleAsync(Guid moduleId);
}