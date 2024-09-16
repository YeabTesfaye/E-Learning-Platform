using System.Reflection;
using Contracts;

namespace Repository
{
    public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}