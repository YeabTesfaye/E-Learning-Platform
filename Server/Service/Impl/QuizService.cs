using AutoMapper;
using Contracts;
using Service.Intefaces;

namespace Service.Impl;

public class QuizService : IQuizService
{
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;
    private readonly IRepositoryManager _repository;

    public QuizService( IRepositoryManager repository, ILoggerManager logger,IMapper mapper)
    {
        _mapper = mapper;
        _logger = logger;
        _repository = repository;
    }
}