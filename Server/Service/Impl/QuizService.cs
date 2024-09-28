using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

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

    public async Task<QuizDto> CreateQuiz(Guid courseId, QuizForCreation quiz, bool trackChanges)
    {
        await CheckIfCourseExists(courseId, trackChanges);
        var quizEntity = _mapper.Map<Quiz>(quiz);
        _repository.Quiz.CreateQuizForCourse(courseId, quizEntity);
        await _repository.SaveAsync();

        var quizToReturn = _mapper.Map<QuizDto>(quizEntity);
        return quizToReturn;
    }

    public async Task DeleteQuiz(Guid id, Guid courseId, bool trackChanges)
    {
        await CheckIfCourseExists(courseId, trackChanges);

        var quiz = await CheckIfQuizExistsAndReturn(id, courseId, trackChanges);

        _repository.Quiz.DeleteQuiz(quiz);
        await _repository.SaveAsync();
    }

    public async Task<QuizDto> GetQuiz(Guid quizId, Guid courseId, bool trackChanges)
    {
        await CheckIfCourseExists(courseId, trackChanges);
        var quiz = await CheckIfQuizExistsAndReturn(quizId, courseId, trackChanges);
        var quizDto = _mapper.Map<QuizDto>(quiz);
        return quizDto;
    }

    public async Task<IEnumerable<QuizDto>> GetQuizzes(Guid courseId, bool trackChanges)
    {
        _ = await _repository.Course.GetCourse(courseId, trackChanges)
        ?? throw new CourseNotFoundException(courseId);

        var quizes = await _repository.Quiz.GetQuizzes(courseId, trackChanges);
        var quizesDto = _mapper.Map<IEnumerable<QuizDto>>(quizes);
        return quizesDto;
    }

    public async Task UpdateQuiz(Guid id, Guid courseId, QuizForUpdateDto quizForUpdate, bool courseTrackChanges, bool quizTrackChanges)
    {
        await CheckIfCourseExists(courseId, courseTrackChanges);
        var quizEntity = await CheckIfQuizExistsAndReturn(id, courseId, courseTrackChanges);
        _mapper.Map(quizForUpdate, quizEntity);
        await _repository.SaveAsync();
    }
    private async Task CheckIfCourseExists(Guid courseId, bool trackChanges)
    {
        _ = await _repository.Course.GetCourse(courseId, trackChanges: false)
         ?? throw new CourseNotFoundException(courseId);
    }

    private async Task<Quiz> CheckIfQuizExistsAndReturn(Guid id, Guid courseId, bool trackChanges)
    {
        var quiz = await _repository.Quiz.GetQuiz(id, courseId, trackChanges: false)
        ?? throw new QuizNotFoundException(id);
        return quiz;

    }
}