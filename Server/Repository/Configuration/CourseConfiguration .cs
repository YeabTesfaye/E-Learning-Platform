using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;


public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasData(
            new Course
            {
                CourseId = new Guid("a56d8b60-2f4d-4b77-8f6d-bd2a5ab7c345"),
                Title = "Fundamentals of Programming",
                Description = "An introductory course on programming basics.",
                Credits = 3,
                InstructorId = new Guid("8d6a9f34-1f6b-4f1b-bb20-38b75f56d9d5")
            },
            new Course
            {
                CourseId = new Guid("b65d8b60-2f4d-4b77-8f6d-cd2a5ab7c345"),
                Title = "Advanced Database Systems",
                Description = "An advanced course covering database management systems.",
                Credits = 4,
                InstructorId = new Guid("8d6a9f34-1f6b-4f1b-bb20-38b75f56d9d5")
            }
        );
    }
}
