using AutoMapper;
using Contracts;
using Entities;
using Service.Intefaces;
using Shared.DataTransferObjects;

namespace Service.Impl;

public sealed class StudentService : IStudentService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public StudentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public void CreateStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public void DeleteStudent(Guid studentId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<StudentDto> GetAllStudents(bool trackChanges)
    {
        try
        {
            var students = _repository.Student.GetAllStudents(trackChanges);
            var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students); // Ensure mapping is done here
            return studentsDto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllStudents)} service method: {ex}");
            throw;

        }
    }

    public IEnumerable<Student> GetStudentById(Guid studentId)
    {
        throw new NotImplementedException();
    }

    public void UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }
}