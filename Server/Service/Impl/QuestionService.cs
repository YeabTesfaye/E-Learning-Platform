using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;

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

    public QuizQuestionDto GetQuestion(Guid quizId, Guid questionId, bool trackChanges)
    {


        // Retrieve the quiz question
        var question = _repository.QuizQuestion.GetQuizQuestion(quizId, questionId, trackChanges)
         ?? throw new QuestionNotFoundException(questionId);

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

}