namespace Service.Intefaces;

public interface IServiceManager
{
    ICourseService CourseService { get; }
    IStudentService StudentService { get; }
    IModuleService ModuleService { get; }
    IEnrolmentService EnrolmentService { get; }
    ILessonService LessonService { get; }
    IQuizAnswerService QuizAnswerService { get; }
    IQuizService QuizService { get; }
    IStudentLessonService StudentLessonService { get; }
    IStudentQuizAttemptService StudentQuizAttemptService { get; }
    IQuizQuestionService QuizQuestionService { get; }
    IAuthenticationService AuthenticationService { get; }
}