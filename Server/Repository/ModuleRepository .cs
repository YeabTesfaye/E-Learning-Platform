using Contracts;
using Entities;

namespace Repository
{
    public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Module> GetAllModules(bool trackChanges)
        {
            return [.. FindAll(trackChanges).OrderBy(m => m.Name)];
        }

        
    }
}