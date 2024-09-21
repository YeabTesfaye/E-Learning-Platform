
using Entities;

namespace Contracts;

public interface IModuleRepository
{
        IEnumerable<Module> GetModules(Guid courseId,bool trackChanges);

}