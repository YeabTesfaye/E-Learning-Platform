using AutoMapper;
using Contracts;
using Entities;
using Service.Intefaces;
using Shared.DataTransferObjects;

namespace Service.Impl;

public sealed class InstructorService : IInstructorService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public InstructorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public void CreateInstructor(Instructor instructor)
    {
        throw new NotImplementedException();
    }

    public void DeleteInstructor(Guid instructorId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<InstructorDto> GetAllInstructors(bool trackChanges)
    {
        try
        {
            var instructores = _repository.Course.GetAllCourses(trackChanges);
            var instructoresDto = _mapper.Map<IEnumerable<InstructorDto>>(instructores);
            return instructoresDto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllInstructors)} service method: {ex}");
            throw;

        }
    }

    public InstructorDto GetInstructorById(Guid instructorId)
    {
        throw new NotImplementedException();
    }

    public void UpdateInstructor(Instructor instructor)
    {
        throw new NotImplementedException();
    }
}