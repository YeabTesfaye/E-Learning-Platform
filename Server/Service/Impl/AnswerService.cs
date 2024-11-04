using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Impl;

public class AnswerService(IRepositoryManager repository, IMapper mapper) : IAnswerService
{
    private readonly IMapper _mapper = mapper;
    private readonly IRepositoryManager _repository = repository;

    public async Task<IEnumerable<AnswerDto>> GetAnswersByQuestion(Guid questionId, bool trackChanges)
    {
        var answers = await _repository.Answer.GetAnswersByQuestion(questionId, trackChanges);
        return _mapper.Map<IEnumerable<AnswerDto>>(answers);
    }

    public async Task<AnswerDto> GetAnswerById(Guid answerId, Guid questionId, bool trackChanges)
    {
        var answer = await CheckIfAnswerExistsAndReturn(answerId, questionId, trackChanges);
        return _mapper.Map<AnswerDto>(answer);
    }

    public async Task<AnswerDto> CreateAnswer(Guid questionId, AnswerForCreation answerForCreation, bool trackChanges)
    {
        await CheckIfQuestionExists(questionId, trackChanges);
        var answerEntity = _mapper.Map<Answer>(answerForCreation);

        _repository.Answer.CreateAnswer(questionId, answerEntity);
        await _repository.SaveAsync();

        var quizToReturn = _mapper.Map<AnswerDto>(answerEntity);
        return quizToReturn;
    }

    public async Task DeleteQuizAnswer(Guid answerId, Guid questionId, bool trackChanges)
    {
        await CheckIfAnswerExists(answerId, trackChanges);

        var quizAnswer = await CheckIfAnswerExistsAndReturn(answerId, questionId, trackChanges);

        _repository.Answer.DeleteQuizAnswer(quizAnswer);
        await _repository.SaveAsync();
    }

    
    private async Task<Answer> CheckIfAnswerExistsAndReturn(Guid answerId, Guid questionId, bool trackChanges)
    {
        var answer = await _repository.Answer.GetAnswerById(answerId, questionId, trackChanges)
        ?? throw new AnswerNotFoundException(answerId);
        return answer;
    }
    private async Task CheckIfAnswerExists(Guid questionId, bool trackChanges)
    {
        _ = await _repository.Question.GetQuestionsByQuiz(questionId, trackChanges)
          ?? throw new QuestionNotFoundException(questionId);
    }

    private async Task CheckIfQuestionExists(Guid questionId, bool trackChanges)
    {
        _ = await _repository.Question.GetQuizQuestion(questionId, trackChanges)
           ?? throw new QuestionNotFoundException(questionId);

    }
}