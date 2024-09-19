using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class ModuleConfiguration : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder.HasData
                (
                    new Module
                    {
                        Id = new Guid("f1a2b3c4-d5e6-4f0a-b9a2-fd1234567890"),
                        CourseId = new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"),
                        Name = "Introduction to Programming",
                        Number = 1
                    },
                    new Module
                    {
                        Id = new Guid("b2c3d4e5-f6a7-4b0c-b9a2-fd1234567890"),
                        CourseId = new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"),
                        Name = "Advanced Programming Concepts",
                        Number = 2
                    }
                );
    }
}