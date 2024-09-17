using Entities;

namespace Service.Intefaces;

public interface ICertificateService
{
    Task<IEnumerable<Certificate>> GetAllCertificatesAsync();
    Task<Certificate> GetCertificateByIdAsync(Guid certificateId);
    Task CreateCertificateAsync(Certificate certificate);
    Task UpdateCertificateAsync(Certificate certificate);
    Task DeleteCertificateAsync(Guid certificateId);
}