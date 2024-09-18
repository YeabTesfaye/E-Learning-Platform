using AutoMapper;
using Contracts;
using Service.Intefaces;

namespace Service.Impl;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ICourseService> _courseService;
    private readonly Lazy<IStudentService> _studentService;
    private readonly Lazy<IInstructorService> _instructorService;
    private readonly Lazy<IModuleService> _moduleService;
    private readonly Lazy<ICertificateService> _certificateService;
    private readonly Lazy<IStudentCourseService> _studentCourseService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger,IMapper mapper)
    {
        _courseService = new Lazy<ICourseService>(() => new CourseService(repositoryManager, logger, mapper));
        _studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager, logger, mapper));
        _instructorService = new Lazy<IInstructorService>(() => new InstructorService(repositoryManager, logger,mapper));
        _moduleService = new Lazy<IModuleService>(() => new ModuleService(repositoryManager, logger,mapper));
        _certificateService = new Lazy<ICertificateService>(() => new CertificateService(repositoryManager, logger,mapper));
        _studentCourseService = new Lazy<IStudentCourseService>(() => new StudentCourseService(repositoryManager, logger,mapper));
    }
    public ICourseService CourseService => _courseService.Value;
    public IStudentService StudentService => _studentService.Value;
    public IInstructorService InstructorService => _instructorService.Value;
    public IModuleService ModuleService => _moduleService.Value;
    public ICertificateService CertificateService => _certificateService.Value;
    public IStudentCourseService StudentCourseService => _studentCourseService.Value;
}