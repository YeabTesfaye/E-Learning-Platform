using Contracts;
using Entities;

namespace Repository;

public class CertificateRepository : RepositoryBase<Certificate>, ICertificateRepository
{
    public CertificateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Certificate> GetAllCertificates(bool trackChanges)
    {
        return [.. FindAll(trackChanges).OrderBy(c => c.Course)];
    }
 
}