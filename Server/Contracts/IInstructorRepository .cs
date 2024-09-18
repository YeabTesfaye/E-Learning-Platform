using Entities;

namespace Contracts;

public interface IInstructorRepository
{
    IEnumerable<Instructor> GetAllInstructors(bool trackChanges);

}