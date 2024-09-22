using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;

namespace Service.Impl;

public class QuizAnswerService : IQuizAnswerService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public QuizAnswerService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }
    public IEnumerable<QuizAnswerDto> GetAnswersByQuestion(Guid questionId, bool trackChanges)
    {
        var answers = _repository.QuizAnswer.GetAnswersByQuestion(questionId, trackChanges);
        return _mapper.Map<IEnumerable<QuizAnswerDto>>(answers);
    }

    public QuizAnswerDto GetAnswerById(Guid questionId, Guid answerId, bool trackChanges)
    {
        var answer = _repository.QuizAnswer.GetAnswerById(questionId, answerId, trackChanges)
        ?? throw new AnswerNotFoundException(answerId);
        return _mapper.Map<QuizAnswerDto>(answer);
    }
}