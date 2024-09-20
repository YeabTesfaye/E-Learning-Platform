using AutoMapper;
using Contracts;

namespace Service.Impl;

public class StudentLessonService : IStudentLessonService
{
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;
    private readonly IRepositoryManager _repository;

    public StudentLessonService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _mapper = mapper;
        _logger = logger;
        _repository = repository;
    }
}