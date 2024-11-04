using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.RequestFeatures;

namespace Service.Impl;

public sealed class StudentService
(IRepositoryManager repository, IMapper mapper) : IStudentService
{
    private readonly IRepositoryManager _repository = repository;
    private readonly IMapper _mapper = mapper;

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

        if (!studentParameters.ValidAgeRange)
            throw new MaxAgeRangeBadRequestException("Max age can't be less than min age.");
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


    private async Task<Student> GetStudentAndCheckIfItExists(Guid Id, bool trackChanges)
    {
        var student = await _repository.Student.GetStudent(Id, trackChanges)
         ?? throw new StudentNotFoundException(Id);
        return student;
    }

}