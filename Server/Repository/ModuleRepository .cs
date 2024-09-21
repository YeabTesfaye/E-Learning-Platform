using Contracts;
using Entities;

namespace Repository
{
    public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Module> GetModules(Guid courseId, bool trackChanges)
        => [.. FindByCondition(m => m.CourseId.Equals(courseId), trackChanges).OrderBy(m => m.Name)];
    }
}