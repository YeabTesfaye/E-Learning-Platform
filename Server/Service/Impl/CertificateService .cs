using Contracts;
using Entities;
using Service.Intefaces;

namespace Service.Impl;

public sealed class CertificateService : ICertificateService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public CertificateService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public Task CreateCertificateAsync(Certificate certificate)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCertificateAsync(Guid certificateId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Certificate>> GetAllCertificatesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Certificate> GetCertificateByIdAsync(Guid certificateId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCertificateAsync(Certificate certificate)
    {
        throw new NotImplementedException();
    }
}