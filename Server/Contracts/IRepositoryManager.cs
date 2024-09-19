namespace Contracts;

public interface IRepositoryManager
{
    ICourseRepository Course { get; }
    IStudentRepository Student { get; }
    IModuleRepository Module { get; } 
    void Save();
}