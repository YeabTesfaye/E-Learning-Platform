namespace Service;

using AutoMapper;
using Entities;
using Shared.DataTransferObjects;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Ensure this mapping exists
        CreateMap<Student, StudentDto>()
        .ForMember(dest =>
         dest.FullName, src => src.MapFrom(x => x.FirstName + " " + x.LastName))
         .ForMember( dest => dest.Email, src => src.MapFrom(x => x.EmailAddress));
         
        CreateMap<Course, CourseDto>();
        CreateMap<Module, ModuleDto>();
        CreateMap<Enrolment, EnrolmentDto>();
        CreateMap<Lesson, LessonDto>();
        CreateMap<QuizAnswer, QuizAnswerDto>();
        CreateMap<Quiz, QuizDto>();
        CreateMap<QuizQuestion, QuizQuestionDto>();
        CreateMap<StudentLesson, StudentLessonDto>();
        CreateMap<StudentQuizAttempt, StudentQuizAttemptDto>();

    }
}
