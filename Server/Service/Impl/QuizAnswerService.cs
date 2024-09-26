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
        var answer = await _repository.QuizAnswer.GetAnswerById(questionId, answerId, trackChanges)
        ?? throw new AnswerNotFoundException(answerId);
        return _mapper.Map<QuizAnswerDto>(answer);
    }

    public async Task<QuizAnswerDto> CreateAnswer(Guid questionId, QuizAnswerForCreation quizAnswer, bool trackChanges)
    {
        _ = await _repository.QuizQuestion.GetQuestionsByQuiz(questionId, trackChanges)
        ?? throw new QuestionNotFoundException(questionId);
        var answerEntity = _mapper.Map<QuizAnswer>(quizAnswer);

        _repository.QuizAnswer.CreateAnswer(questionId, answerEntity);
        await _repository.SaveAsync();

        var quizToReturn = _mapper.Map<QuizAnswerDto>(answerEntity);
        return quizToReturn;
    }

    public async Task DeleteQuizAnswer(Guid id, Guid questionId, bool trackChanges)
    {
        _ = await _repository.QuizQuestion.GetQuestionsByQuiz(questionId, trackChanges)
                ?? throw new QuestionNotFoundException(questionId);

        var quizAnswer = await _repository.QuizAnswer.GetAnswerById(questionId, id, trackChanges: false)
         ?? throw new AnswerNotFoundException(id);

        _repository.QuizAnswer.DeleteQuizAnswer(quizAnswer);
        await _repository.SaveAsync();
    }

    public async Task UpdateQuizAnswer(Guid Id, Guid questionId, QuizAnswerForUpdateDto quizAnswerForUpdate,
    bool questionTrackChanges, bool quizTrackChanges)
    {
        _ =await _repository.QuizQuestion.GetQuizQuestion(questionId, questionTrackChanges)
        ?? throw new QuestionNotFoundException(questionId);

        var quizAnswerEntity =await _repository.QuizAnswer.GetAnswerById(questionId, Id, quizTrackChanges)
        ?? throw new QuizAttemptNotFoundException(Id);
        _mapper.Map(quizAnswerForUpdate, quizAnswerEntity);
       await _repository.SaveAsync();
    }
}