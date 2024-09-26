namespace Contracts;

public interface IRepositoryManager
{
    ICourseRepository Course { get; }
    IStudentRepository Student { get; }
    IModuleRepository Module { get; }
    IEnrolmentRepository Enrolment {get;} 
    ILessonRepository Lesson {get;}
    IQuizAnswerRepository QuizAnswer {get;}
    IQuizQuestionRepository QuizQuestion {get;}
    IQuizRepository Quiz {get;}
    IStudentLessonRepository StudentLesson {get;}
    IStudentQuizAttemptRepository StudentQuizAttempt {get;}
    Task SaveAsync();
}