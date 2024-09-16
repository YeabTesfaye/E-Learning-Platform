namespace Contracts;

public interface IRepositoryManager
{
    ICourseRepository Course { get; }
    IStudentRepository Student { get; }
    IInstructorRepository Instructor { get; }
    IModuleRepository Module { get; }
    ICertificateRepository Certificate { get; }
    void Save();
}