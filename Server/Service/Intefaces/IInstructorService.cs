using Entities;
using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface IInstructorService
{
    IEnumerable<InstructorDto> GetAllInstructors(bool trackChanges);
    InstructorDto GetInstructorById(Guid instructorId);
    void CreateInstructor(Instructor instructor);
    void UpdateInstructor(Instructor instructor);
    void DeleteInstructor(Guid instructorId);
}