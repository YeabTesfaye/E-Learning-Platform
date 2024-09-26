using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
  public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
  {
    public ModuleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateModuleForCourse(Guid courseId, Module module)
    {
      module.CourseId = courseId;
      Create(module);
    }

    public void DeleteModule(Module module)
    => Delete(module);

    public async Task<Module?> GetModule(Guid Id, Guid courseId, bool trackChanges)
=> await FindByCondition(m => m.Id.Equals(Id) && m.CourseId.Equals(courseId), trackChanges)
  .SingleOrDefaultAsync();

    public async Task<Module?> GetModule(Guid Id, bool trackChanges)
     => await FindByCondition(m => m.Id.Equals(Id), trackChanges)
      .SingleOrDefaultAsync();
    public async Task<IEnumerable<Module>> GetModules(Guid courseId, bool trackChanges)
=> await FindByCondition(m => m.CourseId.Equals(courseId), trackChanges)
  .OrderBy(m => m.Name).ToListAsync();
  }
}