using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Intefaces;

namespace Service.Impl;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ICourseService> _courseService;
    private readonly Lazy<IStudentService> _studentService;
    private readonly Lazy<IModuleService> _moduleService;
    private readonly Lazy<IEnrolmentService> _enrolmentService;
    private readonly Lazy<ILessonService> _lessonService;
    private readonly Lazy<IQuizAnswerService> _quizAnswerService;
    private readonly Lazy<IQuizService> _quizService;
    private readonly Lazy<IStudentLessonService> _studentLessonService;
    private readonly Lazy<IStudentQuizAttemptService> _studentQuizAttemptService;
    private readonly Lazy<IQuizQuestionService> _quizQuestionService;
    private readonly Lazy<IAuthenticationService> _authenticationService;
    public ServiceManager(IRepositoryManager repository, IMapper mapper,
    UserManager<User> userManager, IConfiguration configuration)
    {
        _courseService = new Lazy<ICourseService>(() => new CourseService(repository,  mapper));
        _studentService = new Lazy<IStudentService>(() => new StudentService(repository,  mapper));
        _moduleService = new Lazy<IModuleService>(() => new ModuleService(repository,  mapper));
        _enrolmentService = new Lazy<IEnrolmentService>(() => new EnrolmentService(repository,  mapper));
        _lessonService = new Lazy<ILessonService>(() => new LessonService(repository,  mapper));
        _quizAnswerService = new Lazy<IQuizAnswerService>(() => new QuizAnswerService(repository,  mapper));
        _quizService = new Lazy<IQuizService>(() => new QuizService(repository,  mapper));
        _studentLessonService = new Lazy<IStudentLessonService>(() => new StudentLessonService(repository,  mapper));
        _studentQuizAttemptService = new Lazy<IStudentQuizAttemptService>(() => new StudentQuizAttemptService(repository,  mapper));
        _quizQuestionService = new Lazy<IQuizQuestionService>(() => new QuizQuestionService(repository,  mapper));
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService( mapper, userManager, configuration));

    }
    public ICourseService CourseService => _courseService.Value;
    public IStudentService StudentService => _studentService.Value;
    public IModuleService ModuleService => _moduleService.Value;

    public IEnrolmentService EnrolmentService => _enrolmentService.Value;

    public ILessonService LessonService => _lessonService.Value;

    public IQuizAnswerService QuizAnswerService => _quizAnswerService.Value;

    public IQuizService QuizService => _quizService.Value;

    public IStudentLessonService StudentLessonService => _studentLessonService.Value;

    public IStudentQuizAttemptService StudentQuizAttemptService => _studentQuizAttemptService.Value;

    public IQuizQuestionService QuizQuestionService => _quizQuestionService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}