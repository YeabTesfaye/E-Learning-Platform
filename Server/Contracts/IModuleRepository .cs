
using Entities;

namespace Contracts;

public interface IModuleRepository
{
        Task<IEnumerable<Module>> GetModules(Guid courseId,bool trackChanges);
        Task<Module> GetModule(Guid Id, Guid courseId, bool trackChanges);
        Task<Module> GetModule(Guid Id,bool trackChanges);
        void CreateModuleForCourse(Guid courseId, Module module);
        void DeleteModule(Module module);

}