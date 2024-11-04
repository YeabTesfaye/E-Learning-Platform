namespace Contracts;

public interface IRepositoryManager
{
    ICourseRepository Course { get; }
    IStudentRepository Student { get; }
    IModuleRepository Module { get; }
    IEnrolmentRepository Enrolment {get;} 
    ILessonRepository Lesson {get;}
    IAnswerRepository Answer {get;}
    IQuestionRepository Question {get;}
    IQuizRepository Quiz {get;}
    IStudentLessonRepository StudentLesson {get;}
    IQuizAttemptRepository QuizAttempt { get; }  
    Task SaveAsync();
}