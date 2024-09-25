using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IModuleService
{
    IEnumerable<ModuleDto> GetModules(Guid courseId, bool trackChanges);
    ModuleDto GetModule(Guid Id, Guid courseId, bool trackChanges);
    ModuleDto CreateModuleForCourse(Guid courseId, ModuleForCreation module, bool trackChanges);
    void UpdateModule(Guid Id,Guid courseId,ModuleForUpdateDto moduleForUpdate,bool courseTrackChanges, bool moduleTrackChanges);
    void DeleteModule(Guid Id,Guid courseId,bool trackChanges);
}