using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ICourseRepository> _courseRepository;
    private readonly Lazy<IStudentRepository> _studentRepository;
    private readonly Lazy<IModuleRepository> _moduleRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(repositoryContext));
        _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
        _moduleRepository = new Lazy<IModuleRepository>(() => new ModuleRepository(repositoryContext));
    }
    public ICourseRepository Course => _courseRepository.Value;
    public IStudentRepository Student => _studentRepository.Value;
    public IModuleRepository Module => _moduleRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();

}