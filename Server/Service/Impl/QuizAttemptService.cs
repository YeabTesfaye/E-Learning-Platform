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

public class QuizAttemptService(IRepositoryManager repository, IMapper mapper) : IQuizAttemptService
{
    private readonly IRepositoryManager _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<QuizAttemptDto>> GetAttemptsByStudent(Guid studentId, bool trackChanges)
    {
        var attempts = await _repository.QuizAttempt.GetAttemptsByStudent(studentId, trackChanges);
        return _mapper.Map<IEnumerable<QuizAttemptDto>>(attempts);
    }

    public async Task<QuizAttemptDto> GetAttemptById(Guid studentId, Guid attemptId, bool trackChanges)
    {
        var attempt = await CheckIfQuizAttemptExistsAndReturn(attemptId, studentId, trackChanges);
        return _mapper.Map<QuizAttemptDto>(attempt);
    }

    public async Task<QuizAttemptDto> CreateAttempt(Guid studentId, Guid quizId, QuizAttemptForCreation quizAttemptForCreation, bool trackChanges)
    {
        await CheckIfStudentExists(studentId, trackChanges);
        await CheckIfQuizExists(quizId);

        var quizAttemptEntity = _mapper.Map<QuizAttempt>(quizAttemptForCreation);
        _repository.QuizAttempt.CreateAppempt(studentId, quizId, quizAttemptEntity);
        await _repository.SaveAsync();

        var quizAttemtToReturn = _mapper.Map<QuizAttemptDto>(quizAttemptEntity);
        return quizAttemtToReturn;
    }

    public async Task DeleteStudentQuizAttempt(Guid attemptId, Guid studentId, bool trackChanges)
    {
        await CheckIfStudentExists(studentId, trackChanges);

        var studentQuizAttempt = await CheckIfQuizAttemptExistsAndReturn(attemptId,studentId, trackChanges);

        _repository.QuizAttempt.DeleteAttempt(studentQuizAttempt);
        await _repository.SaveAsync();
    }

    public async Task UpdateStudentQuizAttempt(Guid Id, Guid studentId, QuizAttemptForUpdateDto studentQuizAttemptForUpdate,
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
    private async Task<QuizAttempt> CheckIfQuizAttemptExistsAndReturn(Guid attemptId, Guid studentId, bool trackChanges)
    {
        var attempt = await _repository.QuizAttempt.GetAttemptById(attemptId, studentId, trackChanges)
        ?? throw new QuizAttemptNotFoundException(attemptId);
        return attempt;

    }
}