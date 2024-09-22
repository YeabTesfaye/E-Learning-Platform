using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;

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
}