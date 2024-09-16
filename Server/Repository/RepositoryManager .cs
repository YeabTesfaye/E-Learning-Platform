using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ICourseRepository> _courseRepository;
    private readonly Lazy<IStudentRepository> _studentRepository;
    private readonly Lazy<IInstructorRepository> _instructorRepository;
    private readonly Lazy<IModuleRepository> _moduleRepository;
    private readonly Lazy<ICertificateRepository> _certificateRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(repositoryContext));
        _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
        _instructorRepository = new Lazy<IInstructorRepository>(() => new InstructorRepository(repositoryContext));
        _moduleRepository = new Lazy<IModuleRepository>(() => new ModuleRepository(repositoryContext));
        _certificateRepository = new Lazy<ICertificateRepository>(() => new CertificateRepository(repositoryContext));
    }
    public ICourseRepository Course => _courseRepository.Value;
    public IStudentRepository Student => _studentRepository.Value;
    public IInstructorRepository Instructor => _instructorRepository.Value;
    public IModuleRepository Module => _moduleRepository.Value;
    public ICertificateRepository Certificate => _certificateRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();

}