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

    public IEnumerable<StudentQuizAttemptDto> GetAttemptsByStudent(Guid studentId, bool trackChanges)
    {
        var attempts = _repository.StudentQuizAttempt.GetAttemptsByStudent(studentId, trackChanges);
        return _mapper.Map<IEnumerable<StudentQuizAttemptDto>>(attempts);
    }

    public StudentQuizAttemptDto GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges)
    {
        var attempt = _repository.StudentQuizAttempt.GetAttemptById(studentId, attemptId, trackChanges)
        ?? throw new QuizAttemptNotFoundException(attemptId);
        return _mapper.Map<StudentQuizAttemptDto>(attempt);
    }

    public StudentQuizAttemptDto CreateAttempt(Guid studentId, Guid quizId, StudentQuizAttemptForCreation studentQuizAttempt, bool trackChanges)
    {
        _ = _repository.Student.GetStudent(studentId, trackChanges: false)
        ?? throw new StudentNotFoundException(studentId);
        _ = _repository.Quiz.GetQuiz(quizId, trackChanges: false)
        ?? throw new QuizNotFoundException(quizId);

        var quizAttemptEntity = _mapper.Map<StudentQuizAttempt>(studentQuizAttempt);
        _repository.StudentQuizAttempt.CreateAppempt(studentId, quizId, quizAttemptEntity);
        _repository.Save();

        var quizAttemtToReturn = _mapper.Map<StudentQuizAttemptDto>(quizAttemptEntity);
        return quizAttemtToReturn;
    }

    public void DeleteStudentQuizAttempt(Guid id, Guid studentId, bool trackChanges)
    {
        _ = _repository.Student.GetStudent(studentId, trackChanges: false)
       ?? throw new StudentNotFoundException(studentId);


        var studentQuizAttempt = _repository.StudentQuizAttempt.GetAttemptById(studentId, id, trackChanges: false)
        ?? throw new QuizNotFoundException(id);

        _repository.StudentQuizAttempt.DeleteAttempt(studentQuizAttempt);
        _repository.Save();
    }

    public void UpdateStudentQuizAttempt(Guid Id, Guid studentId, StudentQuizAttemptForUpdateDto studentQuizAttemptForUpdate,
    bool quizTrackChanges, bool studentTrackChanges)
    {
        _ = _repository.Student.GetStudent(studentId, studentTrackChanges)
        ?? throw new StudentNotFoundException(studentId);

        var quizAttemptEntity = _repository.StudentQuizAttempt.GetAttemptById(studentId,Id,quizTrackChanges)
         ?? throw new QuizAttemptNotFoundException(Id);
        _mapper.Map(studentQuizAttemptForUpdate,quizAttemptEntity);
        _repository.Save();
    }
}