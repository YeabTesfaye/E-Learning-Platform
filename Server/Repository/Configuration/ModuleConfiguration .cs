using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class ModuleConfiguration : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder.HasData(
            new Module
            {
                ModuleId = new Guid("c56b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"),
                Title = "Introduction to C#",
                Content = "Basic concepts of C# programming language.",
                CourseId = new Guid("a56d8b60-2f4d-4b77-8f6d-bd2a5ab7c345")
            },
            new Module
            {
                ModuleId = new Guid("d65b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"),
                Title = "Database Design",
                Content = "Fundamentals of database design and normalization.",
                CourseId = new Guid("b65d8b60-2f4d-4b77-8f6d-cd2a5ab7c345")
            }
        );
    }
}
