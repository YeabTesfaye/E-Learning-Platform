using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ICourseRepository> _courseRepository;
    private readonly Lazy<IStudentRepository> _studentRepository;
    private readonly Lazy<IModuleRepository> _moduleRepository;
    private readonly Lazy<IEnrolmentRepository> _enrolmentRepository;
    private readonly Lazy<ILessonRepository> _lessonRepository;
    private readonly Lazy<IQuizAnswerRepository> _quizAnswerRepository;
    private readonly Lazy<IQuizQuestionRepository> _quizQuestionRepository;
    private readonly Lazy<IQuizRepository> _quizRepository;
    private readonly Lazy<IStudentLessonRepository> _studentLessonRepository;
    private readonly Lazy<IStudentQuizAttemptRepository> _studentQuizAttemptRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        
        _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(repositoryContext));
        _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
        _moduleRepository = new Lazy<IModuleRepository>(() => new ModuleRepository(repositoryContext));
        _enrolmentRepository = new Lazy<IEnrolmentRepository>(() => new EnrolmentRepository(repositoryContext));
        _lessonRepository  = new Lazy<ILessonRepository>(() => new LessonRepository(repositoryContext));
        _quizAnswerRepository = new Lazy<IQuizAnswerRepository>(() => new QuizAnswerRepository(repositoryContext));
        _quizQuestionRepository = new Lazy<IQuizQuestionRepository>(() => new QuizQuestionRepository(repositoryContext));
        _quizRepository = new Lazy<IQuizRepository>(() => new QuizRepository(repositoryContext));
        _studentLessonRepository = new Lazy<IStudentLessonRepository>(() => new StudentLessonRepository(repositoryContext));
        _studentQuizAttemptRepository = new Lazy<IStudentQuizAttemptRepository>(() => new StudentQuizAttemptRepository(repositoryContext));
    }

    // Properties to expose each repository
    public ICourseRepository Course => _courseRepository.Value;
    public IStudentRepository Student => _studentRepository.Value;
    public IModuleRepository Module => _moduleRepository.Value;
    public IEnrolmentRepository Enrolment => _enrolmentRepository.Value;
    public ILessonRepository Lesson => _lessonRepository.Value;
    public IQuizAnswerRepository QuizAnswer => _quizAnswerRepository.Value;
    public IQuizQuestionRepository QuizQuestion => _quizQuestionRepository.Value;
    public IQuizRepository Quiz => _quizRepository.Value;
    public IStudentLessonRepository StudentLesson => _studentLessonRepository.Value;
    public IStudentQuizAttemptRepository StudentQuizAttempt => _studentQuizAttemptRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();
}
