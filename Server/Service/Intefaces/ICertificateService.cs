using Entities;
using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface ICertificateService
{
    IEnumerable<CertificateDto> GetAllCertificates(bool trackChanges);
    CertificateDto GetCertificateById(Guid certificateId);
    void CreateCertificate(Certificate certificate);
    void UpdateCertificate(Certificate certificate);
    void DeleteCertificate(Guid certificateId);
}