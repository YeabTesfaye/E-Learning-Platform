using Entities;

namespace Service.Intefaces;

public interface IInstructorService
{
    Task<IEnumerable<Instructor>> GetAllInstructorsAsync();
    Task<Instructor> GetInstructorByIdAsync(Guid instructorId);
    Task CreateInstructorAsync(Instructor instructor);
    Task UpdateInstructorAsync(Instructor instructor);
    Task DeleteInstructorAsync(Guid instructorId);
}