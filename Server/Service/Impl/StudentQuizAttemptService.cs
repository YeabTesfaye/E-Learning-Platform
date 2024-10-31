using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace Service.Impl;

public class StudentQuizAttemptService(IRepositoryManager repository, IMapper mapper) : IStudentQuizAttemptService
{
    private readonly IRepositoryManager _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<StudentQuizAttemptDto>> GetAttemptsByStudent(Guid studentId, bool trackChanges)
    {
        var attempts = await _repository.StudentQuizAttempt.GetAttemptsByStudent(studentId, trackChanges);
        return _mapper.Map<IEnumerable<StudentQuizAttemptDto>>(attempts);
    }

    public async Task<StudentQuizAttemptDto> GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges)
    {
        var attempt = await CheckIfQuizAttemptExistsAndReturn(attemptId, studentId, trackChanges);
        return _mapper.Map<StudentQuizAttemptDto>(attempt);
    }

    public async Task<StudentQuizAttemptDto> CreateAttempt(Guid studentId, Guid quizId, StudentQuizAttemptForCreation studentQuizAttempt, bool trackChanges)
    {
        await CheckIfStudentExists(studentId, trackChanges);
        await CheckIfQuizExists(quizId);

        var quizAttemptEntity = _mapper.Map<StudentQuizAttempt>(studentQuizAttempt);
        _repository.StudentQuizAttempt.CreateAppempt(studentId, quizId, quizAttemptEntity);
        await _repository.SaveAsync();

        var quizAttemtToReturn = _mapper.Map<StudentQuizAttemptDto>(quizAttemptEntity);
        return quizAttemtToReturn;
    }

    public async Task DeleteStudentQuizAttempt(Guid id, Guid studentId, bool trackChanges)
    {
        await CheckIfStudentExists(studentId, trackChanges);

        var studentQuizAttempt = await CheckIfQuizAttemptExistsAndReturn(studentId, id, trackChanges);

        _repository.StudentQuizAttempt.DeleteAttempt(studentQuizAttempt);
        await _repository.SaveAsync();
    }

    public async Task UpdateStudentQuizAttempt(Guid Id, Guid studentId, StudentQuizAttemptForUpdateDto studentQuizAttemptForUpdate,
    bool quizTrackChanges, bool studentTrackChanges)
    {
        await CheckIfStudentExists(studentId, studentTrackChanges);

        var quizAttemptEntity = await CheckIfQuizAttemptExistsAndReturn(studentId, Id, quizTrackChanges);
        _mapper.Map(studentQuizAttemptForUpdate, quizAttemptEntity);
        await _repository.SaveAsync();
    }
    private async Task CheckIfStudentExists(Guid studentId, bool trackChanges)
    {
        var student = await _repository.Student.GetStudent(studentId, trackChanges: false)
         ?? throw new StudentNotFoundException(studentId);
    }
    private async Task CheckIfQuizExists(Guid quizId)
    {
        _ = await _repository.Quiz.GetQuiz(quizId, trackChanges: false)
         ?? throw new QuizNotFoundException(quizId);
    }
    private async Task<StudentQuizAttempt> CheckIfQuizAttemptExistsAndReturn(Guid attemptId, Guid studentId, bool trackChanges)
    {
        var attempt = await _repository.StudentQuizAttempt.GetAttemptById(studentId, attemptId, trackChanges)
        ?? throw new QuizAttemptNotFoundException(attemptId);
        return attempt;

    }
}