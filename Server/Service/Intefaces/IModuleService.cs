using System.Reflection;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Intefaces;

public interface IModuleService
{
    IEnumerable<ModuleDto> GetModules(Guid courseId, bool trackChanges);
    ModuleDto GetModule(Guid Id, Guid courseId, bool trackChanges);
    ModuleDto CreateModuleForCourse(Guid courseId, ModuleForCreation module, bool trackChanges);
    void UpdateModule(Module module);
    void DeleteModule(Guid Id,Guid courseId,bool trackChanges);
}