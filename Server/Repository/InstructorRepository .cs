using Contracts;
using Entities;

namespace Repository;

public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
{
    public InstructorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}