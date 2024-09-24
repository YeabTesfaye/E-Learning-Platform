using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

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

    public QuizAnswerDto CreateAnswer(Guid questionId, QuizAnswerForCreation quizAnswer, bool trackChanges)
    {
        _ = _repository.QuizQuestion.GetQuestionsByQuiz(questionId, trackChanges)
        ?? throw new QuestionNotFoundException(questionId);
        var answerEntity = _mapper.Map<QuizAnswer>(quizAnswer);

        _repository.QuizAnswer.CreateAnswer(questionId, answerEntity);
        _repository.Save();

        var quizToReturn = _mapper.Map<QuizAnswerDto>(answerEntity);
        return quizToReturn;
    }

    public void DeleteQuizAnswer(Guid id, Guid questionId, bool trackChanges)
    {
        _ = _repository.QuizQuestion.GetQuestionsByQuiz(questionId, trackChanges)
                ?? throw new QuestionNotFoundException(questionId);

        var quizAnswer = _repository.QuizAnswer.GetAnswerById(questionId, id, trackChanges: false)
         ?? throw new AnswerNotFoundException(id);

        _repository.QuizAnswer.DeleteQuizAnswer(quizAnswer);
        _repository.Save();
    }
}