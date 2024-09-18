using Entities;

namespace Contracts;

public interface ICertificateRepository
{
    IEnumerable<Certificate> GetAllCertificates(bool trackChanges);

}