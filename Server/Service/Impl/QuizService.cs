using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

namespace Service.Impl;

public class QuizService(IRepositoryManager repository, IMapper mapper) : IQuizService
{
    private readonly IMapper _mapper = mapper;
    private readonly IRepositoryManager _repository = repository;

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
        var quiz = await CheckIfQuizExistsAndReturn( quizId,courseId, trackChanges);
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

   
    private async Task CheckIfCourseExists(Guid courseId, bool trackChanges)
    {
        _ = await _repository.Course.GetCourse(courseId, trackChanges: false)
         ?? throw new CourseNotFoundException(courseId);
    }

    private async Task<Quiz> CheckIfQuizExistsAndReturn(Guid quizId, Guid courseId, bool trackChanges)
    {
        var quiz = await _repository.Quiz.GetQuiz(quizId, courseId, trackChanges: false)
        ?? throw new QuizNotFoundException(quizId);
        return quiz;

    }
}