using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;

namespace Service.Impl;

public class QuizService : IQuizService
{
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;
    private readonly IRepositoryManager _repository;

    public QuizService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _mapper = mapper;
        _logger = logger;
        _repository = repository;
    }

    public QuizDto GetQuiz(Guid courseId, Guid quizId, bool trackChanges)
    {
        _ = _repository.Course.GetCourse(courseId, trackChanges)
                ?? throw new CourseNotFoundException(courseId);
        var quiz = _repository.Quiz.GetQuiz(courseId,quizId,trackChanges) 
        ?? throw new QuizNotFoundException(quizId);
        var quizDto = _mapper.Map<QuizDto>(quiz);
        return quizDto;
    }

    public IEnumerable<QuizDto> GetQuizzes(Guid courseId, bool trackChanges)
    {
        _ = _repository.Course.GetCourse(courseId, trackChanges)
        ?? throw new CourseNotFoundException(courseId);

        var quizes = _repository.Quiz.GetQuizzes(courseId, trackChanges);
        var quizesDto = _mapper.Map<IEnumerable<QuizDto>>(quizes);
        return quizesDto;
    }
}