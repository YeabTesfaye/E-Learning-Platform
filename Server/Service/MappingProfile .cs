namespace Service;

using AutoMapper;
using Entities;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Ensure this mapping exists
        CreateMap<Student, StudentDto>()
        .ForMember(dest =>
         dest.FullName, src => src.MapFrom(x => x.FirstName + " " + x.LastName))
         .ForMember(dest => dest.Email, src => src.MapFrom(x => x.EmailAddress));


        CreateMap<Course, CourseDto>();
        CreateMap<Module, ModuleDto>().ReverseMap();
        CreateMap<Enrolment, EnrolmentDto>();
        CreateMap<Lesson, LessonDto>().ReverseMap();
        CreateMap<QuizAnswer, QuizAnswerDto>();
        CreateMap<Quiz, QuizDto>();
        CreateMap<QuizQuestion, QuizQuestionDto>();
        CreateMap<StudentLesson, StudentLessonDto>();
        CreateMap<StudentQuizAttempt, StudentQuizAttemptDto>();

        CreateMap<StudentForCreation, Student>()
        .ForMember(dest => dest.EmailAddress, src => src.MapFrom(x => x.Email));
        CreateMap<CourseForCreationDto, Course>();
        CreateMap<ModuleForCreation, Module>();
        CreateMap<ModuleForCreation,ModuleDto>();
        CreateMap<LessonForCreation, Lesson>();
        CreateMap<EnrolmentForCreation, Enrolment>();
        CreateMap<QuizForCreation, Quiz>();
        CreateMap<QuizQuestionForCreation, QuizQuestion>();
        CreateMap<StudentQuizAttemptForCreation, StudentQuizAttempt>();
        CreateMap<QuizAnswerForCreation, QuizAnswer>();
        CreateMap<StudentLessonForCreation,StudentLesson>();


    }
}
