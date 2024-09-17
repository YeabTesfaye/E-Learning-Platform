using Service.Intefaces;

namespace Service;

public interface IServiceManager
{
    ICourseService CourseService { get; }
    IStudentService StudentService { get; }
    IInstructorService InstructorService { get; }
    IModuleService ModuleService { get; }
    ICertificateService CertificateService { get; }
    IStudentCourseService StudentCourseService { get; }
}