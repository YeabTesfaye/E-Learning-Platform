using AutoMapper;
using Contracts;
using Service.Intefaces;

namespace Service.Impl;

public class QuizAnswerService : IQuizAnswerService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public QuizAnswerService( IRepositoryManager repository,ILoggerManager logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }
}