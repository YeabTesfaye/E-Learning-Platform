namespace Service;

using AutoMapper;
using Entities;
using Shared.DataTransferObjects;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

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
        CreateMap<Answer, AnswerDto>();
        CreateMap<Quiz, QuizDto>();
        CreateMap<Question, QuestionDto>();
        CreateMap<StudentLesson, StudentLessonDto>();
        CreateMap<QuizAttempt, QuizAttemptDto>();

        CreateMap<StudentForCreation, Student>()
        .ForMember(dest => dest.EmailAddress, src => src.MapFrom(x => x.Email));
        CreateMap<CourseForCreationDto, Course>();
        CreateMap<ModuleForCreation, Module>();
        CreateMap<ModuleForCreation, ModuleDto>();
        CreateMap<LessonForCreation, Lesson>();
        CreateMap<EnrolmentForCreation, Enrolment>();
        CreateMap<QuizForCreation, Quiz>();
        CreateMap<QuestionForCreation, Question>();
        CreateMap<QuizAttemptForCreation,QuizAttempt>();
        CreateMap<AnswerForCreation, Answer>();
        CreateMap<StudentLessonForCreation, StudentLesson>();

        CreateMap<CourseForUpdateDto, Course>();
        CreateMap<EnrolmentForUpdateDto, Enrolment>();
        CreateMap<LessonForUpdateDto, Lesson>();
        CreateMap<ModuleForUpdateDto, Module>();
        CreateMap<AnswerForUpdateDto, Answer>();
        CreateMap<QuizForUpdateDto, Quiz>();
        CreateMap<QuestionForUpdateDto, Question>();
        CreateMap<StudentForUpdateDto, Student>()
        .ForMember(dest => dest.EmailAddress, src => src.MapFrom(x => x.Email));
        CreateMap<StudentLessonForUpdateDto, StudentLesson>();
        CreateMap<QuizAttemptForUpdateDto, QuizAttempt>();

        CreateMap<UserForRegistrationDto, User>();



    }
}
