using AutoMapper;
using Contracts;
using Entities;
using Service.Intefaces;
using Shared.DataTransferObjects;

namespace Service.Impl;

public sealed class CertificateService : ICertificateService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CertificateService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public void CreateCertificate(Certificate certificate)
    {
        throw new NotImplementedException();
    }

    public void DeleteCertificate(Guid certificateId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CertificateDto> GetAllCertificates(bool trackChanges)
    {
        try
        {
            var certificates = _repository.Certificate.GetAllCertificates(trackChanges);
            var certificatesDto = _mapper.Map<IEnumerable<CertificateDto>>(certificates);
            return certificatesDto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllCertificates)} service method: {ex}");
            throw;

        }
    }

    public CertificateDto GetCertificateById(Guid certificateId)
    {
        throw new NotImplementedException();
    }

    public void UpdateCertificate(Certificate certificate)
    {
        throw new NotImplementedException();
    }

 
}