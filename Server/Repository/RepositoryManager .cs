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
    private readonly Lazy<IAnswerRepository> _answerRepository;
    private readonly Lazy<IQuestionRepository> _questionRepository;
    private readonly Lazy<IQuizRepository> _quizRepository;
    private readonly Lazy<IStudentLessonRepository> _studentLessonRepository;
    private readonly Lazy<IQuizAttemptRepository> _quizAttemptRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;

        _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(repositoryContext));
        _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
        _moduleRepository = new Lazy<IModuleRepository>(() => new ModuleRepository(repositoryContext));
        _enrolmentRepository = new Lazy<IEnrolmentRepository>(() => new EnrolmentRepository(repositoryContext));
        _lessonRepository = new Lazy<ILessonRepository>(() => new LessonRepository(repositoryContext));
        _answerRepository = new Lazy<IAnswerRepository>(() => new AnswerRepository(repositoryContext));
        _questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(repositoryContext));
        _quizRepository = new Lazy<IQuizRepository>(() => new QuizRepository(repositoryContext));
        _studentLessonRepository = new Lazy<IStudentLessonRepository>(() => new StudentLessonRepository(repositoryContext));
        _quizAttemptRepository = new Lazy<IQuizAttemptRepository>(() => new QuizAttemptRepository(repositoryContext));
    }

    public ICourseRepository Course => _courseRepository.Value;
    public IStudentRepository Student => _studentRepository.Value;
    public IModuleRepository Module => _moduleRepository.Value;
    public IEnrolmentRepository Enrolment => _enrolmentRepository.Value;
    public ILessonRepository Lesson => _lessonRepository.Value;
    public IAnswerRepository Answer => _answerRepository.Value;
    public IQuestionRepository Question => _questionRepository.Value;
    public IQuizRepository Quiz => _quizRepository.Value;
    public IStudentLessonRepository StudentLesson => _studentLessonRepository.Value;
    public IQuizAttemptRepository QuizAttempt => _quizAttemptRepository.Value;


    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

}
