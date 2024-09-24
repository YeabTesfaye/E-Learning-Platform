using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

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

    public QuizDto CreateQuiz(Guid courseId, QuizForCreation quiz, bool trackChanges)
    {
        _ = _repository.Course.GetCourse(courseId, trackChanges: false)
         ?? throw new CourseNotFoundException(courseId);

        var quizEntity = _mapper.Map<Quiz>(quiz);
        _repository.Quiz.CreateQuizForCourse(courseId, quizEntity);
        _repository.Save();

        var quizToReturn = _mapper.Map<QuizDto>(quizEntity);
        return quizToReturn;
    }

    public void DeleteQuiz(Guid id, Guid courseId, bool trackChanges)
    {
        _ = _repository.Course.GetCourse(courseId, trackChanges: false)
        ?? throw new CourseNotFoundException(courseId);

        var quiz = _repository.Quiz.GetQuiz(id,courseId,trackChanges:false) 
        ?? throw new QuizNotFoundException(id);

        _repository.Quiz.DeleteQuiz(quiz);
        _repository.Save();
    }

    public QuizDto GetQuiz(Guid quizId, Guid courseId, bool trackChanges)
    {
        _ = _repository.Course.GetCourse(courseId, trackChanges)
                ?? throw new CourseNotFoundException(courseId);
        var quiz = _repository.Quiz.GetQuiz(quizId, courseId, trackChanges)
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