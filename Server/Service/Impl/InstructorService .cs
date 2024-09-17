using Contracts;
using Entities;
using Service.Intefaces;

namespace Service.Impl;

public sealed class InstructorService : IInstructorService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    public InstructorService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public Task CreateInstructorAsync(Instructor instructor)
    {
        throw new NotImplementedException();
    }

    public Task DeleteInstructorAsync(Guid instructorId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Instructor> GetInstructorByIdAsync(Guid instructorId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateInstructorAsync(Instructor instructor)
    {
        throw new NotImplementedException();
    }
}