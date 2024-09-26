using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Intefaces;

public interface IModuleService
{
    Task<IEnumerable<ModuleDto>> GetModules(Guid courseId, bool trackChanges);
    Task<ModuleDto> GetModule(Guid Id, Guid courseId, bool trackChanges);
    Task<ModuleDto> CreateModuleForCourse(Guid courseId, ModuleForCreation module, bool trackChanges);
    Task UpdateModule(Guid Id,Guid courseId,ModuleForUpdateDto moduleForUpdate,bool courseTrackChanges, bool moduleTrackChanges);
    Task DeleteModule(Guid Id,Guid courseId,bool trackChanges);
}