using Contracts;
using Entities;

namespace Repository;

public class CertificateRepository : RepositoryBase<Certificate>, ICertificateRepository
{
    public CertificateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}