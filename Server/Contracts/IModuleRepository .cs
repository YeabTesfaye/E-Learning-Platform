
using Entities;

namespace Contracts;

public interface IModuleRepository
{
        IEnumerable<Module> GetModules(Guid courseId,bool trackChanges);
        Module? GetModule(Guid Id, Guid courseId, bool trackChanges);
        Module? GetModule(Guid Id,bool trackChanges);
        void CreateModuleForCourse(Guid courseId, Module module);

}