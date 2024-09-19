using AutoMapper;
using Contracts;
using Service.Intefaces;

namespace Service.Impl;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ICourseService> _courseService;
    private readonly Lazy<IStudentService> _studentService;
    private readonly Lazy<IModuleService> _moduleService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger,IMapper mapper)
    {
        _courseService = new Lazy<ICourseService>(() => new CourseService(repositoryManager, logger, mapper));
        _studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager, logger, mapper));
        
    }
    public ICourseService CourseService => _courseService.Value;
    public IStudentService StudentService => _studentService.Value;
    public IModuleService ModuleService => _moduleService.Value;
    
}