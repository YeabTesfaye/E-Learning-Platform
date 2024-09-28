using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;
using Shared.RequestFeatures;

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

    public async Task<StudentDto> CreateStudent(StudentForCreation student)
    {
        var studentEntity = _mapper.Map<Student>(student);
        _repository.Student.CreatStudent(studentEntity);
        await _repository.SaveAsync();

        var studentToEntity = _mapper.Map<StudentDto>(studentEntity);
        return studentToEntity;
    }

    public async Task DeleteStudent(Guid id, bool trackChanges)
    {
        var student = await GetStudentAndCheckIfItExists(id, trackChanges);
        _repository.Student.DeleteStudent(student);
        await _repository.SaveAsync();
    }

    public async Task<(IEnumerable<StudentDto> students, MetaData metaData)> GetAllStudents(StudentParameters studentParameters, bool trackChanges)
    {
        var studentWithMetaData = await _repository.Student.GetAllStudents(studentParameters, trackChanges);
        var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(studentWithMetaData);
        return (students: studentsDto, metaData: studentWithMetaData.MetaData);

    }

    public async Task<StudentDto> GetStudent(Guid id, bool trackChanges)
    {
        var student = await GetStudentAndCheckIfItExists(id, trackChanges);
        var studentDto = _mapper.Map<StudentDto>(student);
        return studentDto;
    }


    public async Task UpdateStudent(Guid Id, StudentForUpdateDto studentForUpdate, bool trackChanges)
    {
        var studentEntity = await GetStudentAndCheckIfItExists(Id, trackChanges);

        _mapper.Map(studentForUpdate, studentEntity);
        await _repository.SaveAsync();
    }

    private async Task<Student> GetStudentAndCheckIfItExists(Guid Id, bool trackChanges)
    {
        var student = await _repository.Student.GetStudent(Id, trackChanges: false);
        if (student is null)
            throw new StudentNotFoundException(Id);
        return student;
    }

}