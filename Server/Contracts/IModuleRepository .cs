
using Entities;

namespace Contracts;

public interface IModuleRepository
{
        IEnumerable<Module> GetAllModules(bool trackChanges);

}