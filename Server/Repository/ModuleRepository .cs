using Contracts;
using Entities;

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

    public Module? GetModule(Guid Id, Guid courseId, bool trackChanges)
=> FindByCondition(m => m.Id.Equals(Id) && m.CourseId.Equals(courseId), trackChanges)
  .SingleOrDefault();

    public Module? GetModule(Guid Id, bool trackChanges)
     => FindByCondition(m => m.Id.Equals(Id), trackChanges)
      .SingleOrDefault();
    public IEnumerable<Module> GetModules(Guid courseId, bool trackChanges)
=> [.. FindByCondition(m => m.CourseId.Equals(courseId), trackChanges).OrderBy(m => m.Name)];
  }
}