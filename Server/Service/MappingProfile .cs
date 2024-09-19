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
            .ForCtorParam("FullName", opt =>
            opt.MapFrom(x => string.Join(' ', x.FirstName, x.LastName)));
        CreateMap<Course, CourseDto>();     
        CreateMap<Module, ModuleDto>();

    }
}
