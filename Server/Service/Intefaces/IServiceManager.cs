namespace Service.Intefaces;

public interface IServiceManager
{
    ICourseService CourseService { get; }
    IStudentService StudentService { get; }
    IModuleService ModuleService { get; }
    IEnrolmentService EnrolmentService { get; }
    ILessonService LessonService { get; }
    IAnswerService AnswerService { get; }
    IQuizService QuizService { get; }
    IStudentLessonService StudentLessonService { get; }
    IQuizAttemptService QuizAttemptService  { get; }
    IQuestionService QuestionService { get; }
    IAuthenticationService AuthenticationService { get; }
}