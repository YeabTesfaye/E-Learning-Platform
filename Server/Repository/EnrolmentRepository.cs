using Contracts;
using Entities;

namespace Repository;

public class EnrolmentRepository : RepositoryBase<Enrolment>, IEnrolmentRepository
{
    public EnrolmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}