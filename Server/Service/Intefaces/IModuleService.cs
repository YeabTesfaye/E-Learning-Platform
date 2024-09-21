using System.Reflection;
using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface IModuleService
{
    IEnumerable<ModuleDto> GetModules(Guid courseId,bool trackChanges);
    ModuleDto GetModuleById(Guid moduleId);
    void CreateModule(Module module);
    void UpdateModule(Module module);
    void DeleteModule(Guid moduleId);
}