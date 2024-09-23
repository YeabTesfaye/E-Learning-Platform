using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

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

    public StudentDto CreateStudent(StudentForCreation student)
    {
        var studentEntity = _mapper.Map<Student>(student);
        _repository.Student.CreatStudent(studentEntity);
        _repository.Save();

        var studentToEntity = _mapper.Map<StudentDto>(studentEntity);
        return studentToEntity;
    }

    public void DeleteStudent(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<StudentDto> GetAllStudents(bool trackChanges)
    {
        var students = _repository.Student.GetAllStudents(trackChanges);
        var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students); // Ensure mapping is done here
        return studentsDto;

    }

    public StudentDto GetStudent(Guid id, bool trackChanges)
    {
        var student = _repository.Student.GetStudent(id, trackChanges)
         ?? throw new StudentNotFoundException(id);
        var studentDto = _mapper.Map<StudentDto>(student);
        return studentDto;
    }

    public void UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }


}