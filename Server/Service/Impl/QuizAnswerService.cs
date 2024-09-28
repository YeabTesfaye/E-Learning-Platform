using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

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
    public async Task<IEnumerable<QuizAnswerDto>> GetAnswersByQuestion(Guid questionId, bool trackChanges)
    {
        var answers = await _repository.QuizAnswer.GetAnswersByQuestion(questionId, trackChanges);
        return _mapper.Map<IEnumerable<QuizAnswerDto>>(answers);
    }

    public async Task<QuizAnswerDto> GetAnswerById(Guid questionId, Guid answerId, bool trackChanges)
    {
        var answer = await CheckIfAnswerExistsAndReturn(questionId, answerId, trackChanges);
        return _mapper.Map<QuizAnswerDto>(answer);
    }

    public async Task<QuizAnswerDto> CreateAnswer(Guid questionId, QuizAnswerForCreation quizAnswer, bool trackChanges)
    {
        await CheckIfQuestionExists(questionId, trackChanges);
        var answerEntity = _mapper.Map<QuizAnswer>(quizAnswer);

        _repository.QuizAnswer.CreateAnswer(questionId, answerEntity);
        await _repository.SaveAsync();

        var quizToReturn = _mapper.Map<QuizAnswerDto>(answerEntity);
        return quizToReturn;
    }

    public async Task DeleteQuizAnswer(Guid id, Guid questionId, bool trackChanges)
    {
        await CheckIfAnswerExists(id, trackChanges);

        var quizAnswer = await CheckIfAnswerExistsAndReturn(id, questionId, trackChanges);

        _repository.QuizAnswer.DeleteQuizAnswer(quizAnswer);
        await _repository.SaveAsync();
    }

    public async Task UpdateQuizAnswer(Guid Id, Guid questionId, QuizAnswerForUpdateDto quizAnswerForUpdate,
    bool questionTrackChanges, bool quizTrackChanges)
    {
        await CheckIfQuestionExists(questionId, questionTrackChanges);

        var quizAnswerEntity = await CheckIfAnswerExistsAndReturn(Id, questionId, quizTrackChanges);
        _mapper.Map(quizAnswerForUpdate, quizAnswerEntity);
        await _repository.SaveAsync();
    }
    private async Task<QuizAnswer> CheckIfAnswerExistsAndReturn(Guid questionId, Guid answerId, bool trackChanges)
    {
        var answer = await _repository.QuizAnswer.GetAnswerById(questionId, answerId, trackChanges)
        ?? throw new AnswerNotFoundException(answerId);
        return answer;
    }
    private async Task CheckIfAnswerExists(Guid questionId, bool trackChanges)
    {
        _ = await _repository.QuizQuestion.GetQuestionsByQuiz(questionId, trackChanges)
          ?? throw new QuestionNotFoundException(questionId);
    }
     
    private async Task CheckIfQuestionExists(Guid questionId, bool trackChanges)
    {
        _ = await _repository.QuizQuestion.GetQuizQuestion(questionId, trackChanges)
           ?? throw new QuestionNotFoundException(questionId);

    }
}