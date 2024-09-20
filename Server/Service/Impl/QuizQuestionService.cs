using AutoMapper;
using Contracts;
using Service.Intefaces;

namespace Service.Impl;

public class QuizQuestionService : IQuizQuestionService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;
    
    public QuizQuestionService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _mapper  = mapper;
        _logger = logger;
    }
}