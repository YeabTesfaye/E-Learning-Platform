using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasData
         (
             new Course
             {
                 Id = new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"),
                 Name = "Introduction to Programming",
                 Description = "A beginner-friendly course on programming fundamentals.",
                 Price = 99.99m,
                 IsProgressLimited = false
             },
             new Course
             {
                 Id = new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"),
                 Name = "Advanced Web Development",
                 Description = "Deep dive into modern web development practices and frameworks.",
                 Price = 199.99m,
                 IsProgressLimited = true
             }
         );
    }
}