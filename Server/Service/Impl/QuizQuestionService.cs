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

    public IEnumerable<QuizQuestionDto> GetQuestions(Guid courseId, Guid quizId, bool trackChanges)
    {
        // Check if the quiz exists by courseId and quizId
        var quiz = _repository.Quiz.GetQuiz(courseId, quizId, trackChanges);
        if (quiz == null)
        {
            _logger.LogError($"Quiz with id {quizId} for course {courseId} doesn't exist in the database.");
            throw new QuizNotFoundException(quizId);  // Custom exception
        }

        // Retrieve the questions for the quiz
        var questions = _repository.QuizQuestion.GetQuestionsByQuiz(quizId, trackChanges);

        // Map the questions to QuizQuestionDto
        var questionsDto = _mapper.Map<IEnumerable<QuizQuestionDto>>(questions);

        return questionsDto;
    }

}