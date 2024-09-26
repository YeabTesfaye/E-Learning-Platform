using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Impl;

public class StudentQuizAttemptService : IStudentQuizAttemptService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public StudentQuizAttemptService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentQuizAttemptDto>> GetAttemptsByStudent(Guid studentId, bool trackChanges)
    {
        var attempts = await _repository.StudentQuizAttempt.GetAttemptsByStudent(studentId, trackChanges);
        return _mapper.Map<IEnumerable<StudentQuizAttemptDto>>(attempts);
    }

    public async Task<StudentQuizAttemptDto> GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges)
    {
        var attempt = await _repository.StudentQuizAttempt.GetAttemptById(studentId, attemptId, trackChanges)
        ?? throw new QuizAttemptNotFoundException(attemptId);
        return _mapper.Map<StudentQuizAttemptDto>(attempt);
    }

    public async Task<StudentQuizAttemptDto> CreateAttempt(Guid studentId, Guid quizId, StudentQuizAttemptForCreation studentQuizAttempt, bool trackChanges)
    {
        _ = await _repository.Student.GetStudent(studentId, trackChanges: false)
        ?? throw new StudentNotFoundException(studentId);
        _ = await _repository.Quiz.GetQuiz(quizId, trackChanges: false)
        ?? throw new QuizNotFoundException(quizId);

        var quizAttemptEntity = _mapper.Map<StudentQuizAttempt>(studentQuizAttempt);
        _repository.StudentQuizAttempt.CreateAppempt(studentId, quizId, quizAttemptEntity);
        await _repository.SaveAsync();

        var quizAttemtToReturn = _mapper.Map<StudentQuizAttemptDto>(quizAttemptEntity);
        return quizAttemtToReturn;
    }

    public async Task DeleteStudentQuizAttempt(Guid id, Guid studentId, bool trackChanges)
    {
        _ = await _repository.Student.GetStudent(studentId, trackChanges: false)
       ?? throw new StudentNotFoundException(studentId);


        var studentQuizAttempt = await _repository.StudentQuizAttempt.GetAttemptById(studentId, id, trackChanges: false)
        ?? throw new QuizNotFoundException(id);

        _repository.StudentQuizAttempt.DeleteAttempt(studentQuizAttempt);
        await _repository.SaveAsync();
    }

    public async Task UpdateStudentQuizAttempt(Guid Id, Guid studentId, StudentQuizAttemptForUpdateDto studentQuizAttemptForUpdate,
    bool quizTrackChanges, bool studentTrackChanges)
    {
        _ = await _repository.Student.GetStudent(studentId, studentTrackChanges)
        ?? throw new StudentNotFoundException(studentId);

        var quizAttemptEntity = await _repository.StudentQuizAttempt.GetAttemptById(studentId, Id, quizTrackChanges)
         ?? throw new QuizAttemptNotFoundException(Id);
        _mapper.Map(studentQuizAttemptForUpdate, quizAttemptEntity);
        await _repository.SaveAsync();
    }
}