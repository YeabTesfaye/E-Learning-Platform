using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Impl;

public class QuizQuestionService : IQuizQuestionService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public QuizQuestionService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<QuizQuestionDto> CreateQuestion(Guid quizId, QuizQuestionForCreation question, bool trackChanges)
    {
        _ = await _repository.Quiz.GetQuiz(quizId, trackChanges)
        ?? throw new QuizNotFoundException(quizId);

        var questionEntity = _mapper.Map<QuizQuestion>(question);
        _repository.QuizQuestion.CreateQuizQuestion(quizId, questionEntity);
        await _repository.SaveAsync();

        var questionToReturn = _mapper.Map<QuizQuestionDto>(questionEntity);
        return questionToReturn;
    }

    public async Task DeleteQuizQuestion(Guid Id, Guid quizId, bool trackChanges)
    {
        _ = await _repository.Quiz.GetQuiz(quizId, trackChanges)
       ?? throw new QuizNotFoundException(quizId);

        var quizQuestion = await _repository.QuizQuestion.GetQuizQuestion(Id, quizId, trackChanges: false)
        ?? throw new QuestionNotFoundException(Id);

        _repository.QuizQuestion.DeleteQuizQuestion(quizQuestion);
        await _repository.SaveAsync();
    }


    public async Task<QuizQuestionDto> GetQuestion(Guid Id, Guid quizId, bool trackChanges)
    {
        // Retrieve the quiz question
        var question = await _repository.QuizQuestion.GetQuizQuestion(Id, quizId, trackChanges)
         ?? throw new QuestionNotFoundException(Id);

        var questionDto = _mapper.Map<QuizQuestionDto>(question);

        return questionDto;
    }

    public async Task<IEnumerable<QuizQuestionDto>> GetQuestions(Guid quizId, bool trackChanges)
    {

        // Retrieve the questions for the quiz
        var questions = await _repository.QuizQuestion.GetQuestionsByQuiz(quizId, trackChanges);

        // Map the questions to QuizQuestionDto
        var questionsDto = _mapper.Map<IEnumerable<QuizQuestionDto>>(questions);

        return questionsDto;
    }

    public async Task UpdateQuizQuestion(Guid Id, Guid quizId, QuizQuestionForUpdateDto quizQuestionForUpdate,
    bool quizTrackChanges, bool questionTrackChanges)
    {
        _ = await _repository.Quiz.GetQuiz(quizId, quizTrackChanges)
         ?? throw new QuizNotFoundException(quizId);
        var quesionEntity = await _repository.QuizQuestion.GetQuizQuestion(Id, quizId, questionTrackChanges);
        //  ?? throw new QuestionNotFoundException(Id);

        _mapper.Map(quizQuestionForUpdate, quesionEntity);
        await _repository.SaveAsync();
    }
}