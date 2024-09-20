using AutoMapper;
using Contracts;
using LoggerService;
using Service.Intefaces;

namespace Service.Impl;

public class EnrolmentService : IEnrolmentService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;
    
    public EnrolmentService(IRepositoryManager repository,  ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }
}