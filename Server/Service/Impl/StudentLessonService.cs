using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Intefaces;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;


namespace Service.Impl;

public class StudentLessonService : IStudentLessonService
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public StudentLessonService(IRepositoryManager repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<StudentLessonDto>> GetLessonsByStudent(Guid studentId, Guid lessonId, bool trackChanges)
    {
        var lessons = await _repository.StudentLesson.GetLessonsByStudent(studentId, lessonId, trackChanges);
        return _mapper.Map<IEnumerable<StudentLessonDto>>(lessons);
    }

    public async Task<StudentLessonDto> GetLesson(Guid stlessonId, Guid studentId, Guid lessonId, bool trackChanges)
    {
        var lesson = await CheckIfStLessonExistsAndReturn(stlessonId, studentId, lessonId, trackChanges);
        return _mapper.Map<StudentLessonDto>(lesson);
    }

    public async Task<StudentLessonDto> CreateStudentLesson(Guid studentId, Guid lessonId, StudentLessonForCreation studentLesson, bool trackChanges)
    {
        await CheckIfStudentExists(studentId, trackChanges);
        await CheckIfLessonExists(lessonId, trackChanges);
        var studentLessonEntity = _mapper.Map<StudentLesson>(studentLesson);
        _repository.StudentLesson.CreateLessonForStudent(studentId, lessonId, studentLessonEntity);
        await _repository.SaveAsync();

        var studentLessonToReturn = _mapper.Map<StudentLessonDto>(studentLessonEntity);
        return studentLessonToReturn;
    }

    public async Task DeleteStudentLesson(Guid id, Guid lessonId, Guid studentId, bool trackChanges)
    {
        await CheckIfStudentExists(studentId, trackChanges);
        await CheckIfLessonExists(lessonId, trackChanges);

        var studentLesson = await CheckIfStLessonExistsAndReturn(id, lessonId, studentId, trackChanges);
        _repository.StudentLesson.DeleteStudentLesson(studentLesson);
        await _repository.SaveAsync();

    }

    public async Task UpdateStudntLesson(Guid Id, Guid lessonId, Guid studentId, StudentLessonForUpdateDto studentLessonForUpdate,
    bool stlTrackChanges, bool stuTrackChanges, bool lessonTrackChanges)
    {
        await CheckIfStudentExists(studentId, stuTrackChanges);

        await CheckIfLessonExists(lessonId, lessonTrackChanges);

        var studentLessonEntity = await CheckIfStLessonExistsAndReturn(Id, lessonId, studentId, stlTrackChanges);

        _mapper.Map(studentLessonForUpdate, studentLessonEntity);
        await _repository.SaveAsync();
    }
    private async Task CheckIfStudentExists(Guid studentId, bool trackChanges)
    {
        _ = await _repository.Student.GetStudent(studentId, trackChanges: false)
         ?? throw new StudentNotFoundException(studentId);
    }
    private async Task CheckIfLessonExists(Guid lessonId, bool trackChanges)
    {
        _ = await _repository.Lesson.GetLesson(lessonId, trackChanges: false)
           ?? throw new LessonNotFounException(lessonId);
    }
    private async Task<StudentLesson> CheckIfStLessonExistsAndReturn(Guid stlessonId, Guid studentId, Guid lessonId, bool trackChanges)
    {
        var lesson = await _repository.StudentLesson.StGetLesson(stlessonId, studentId, lessonId, trackChanges)
        ?? throw new StudentLessonNotFound(stlessonId);
        return lesson;

    }
}