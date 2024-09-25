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

    public QuizQuestionDto CreateQuestion(Guid quizId, QuizQuestionForCreation question, bool trackChanges)
    {
        _ = _repository.Quiz.GetQuiz(quizId, trackChanges)
        ?? throw new QuizNotFoundException(quizId);

        var questionEntity = _mapper.Map<QuizQuestion>(question);
        _repository.QuizQuestion.CreateQuizQuestion(quizId, questionEntity);
        _repository.Save();

        var questionToReturn = _mapper.Map<QuizQuestionDto>(questionEntity);
        return questionToReturn;
    }

    public void DeleteQuizQuestion(Guid Id, Guid quizId, bool trackChanges)
    {
        _ = _repository.Quiz.GetQuiz(quizId, trackChanges)
       ?? throw new QuizNotFoundException(quizId);

        var quizQuestion = _repository.QuizQuestion.GetQuizQuestion(Id, quizId, trackChanges: false)
        ?? throw new QuestionNotFoundException(Id);

        _repository.QuizQuestion.DeleteQuizQuestion(quizQuestion);
        _repository.Save();
    }


    public QuizQuestionDto GetQuestion(Guid Id, Guid quizId, bool trackChanges)
    {
        // Retrieve the quiz question
        var question = _repository.QuizQuestion.GetQuizQuestion(Id, quizId, trackChanges)
         ?? throw new QuestionNotFoundException(Id);

        var questionDto = _mapper.Map<QuizQuestionDto>(question);

        return questionDto;
    }

    public IEnumerable<QuizQuestionDto> GetQuestions(Guid quizId, bool trackChanges)
    {

        // Retrieve the questions for the quiz
        var questions = _repository.QuizQuestion.GetQuestionsByQuiz(quizId, trackChanges);

        // Map the questions to QuizQuestionDto
        var questionsDto = _mapper.Map<IEnumerable<QuizQuestionDto>>(questions);

        return questionsDto;
    }

    public void UpdateQuizQuestion(Guid Id, Guid quizId, QuizQuestionForUpdateDto quizQuestionForUpdate,
    bool quizTrackChanges, bool questionTrackChanges)
    {
        _ = _repository.Quiz.GetQuiz(quizId, quizTrackChanges)
         ?? throw new QuizNotFoundException(quizId);
        var quesionEntity = _repository.QuizQuestion.GetQuizQuestion(Id,quizId, questionTrackChanges);
        //  ?? throw new QuestionNotFoundException(Id);

        _mapper.Map(quizQuestionForUpdate, quesionEntity);
        _repository.Save();
    }
}