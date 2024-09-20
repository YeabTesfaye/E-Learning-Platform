using AutoMapper;
using Contracts;
using Service.Intefaces;

namespace Service.Impl;

public class StudentQuizAttemptService : IStudentQuizAttemptService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public StudentQuizAttemptService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
}