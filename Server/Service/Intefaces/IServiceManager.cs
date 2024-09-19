namespace Service.Intefaces;

public interface IServiceManager
{
    ICourseService CourseService { get; }
    IStudentService StudentService { get; }
    IModuleService ModuleService { get; }
}