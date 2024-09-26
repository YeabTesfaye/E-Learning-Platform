using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder) => builder.HasData(
            new Student
            {
                Id = new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e"),
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "john.doe@example.com",
                Sex = "Male",
                Age = 25

            },
            new Student
            {
                Id = new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329"),
                FirstName = "Jane",
                LastName = "Smith",
                EmailAddress = "jane.smith@example.com",
                Sex = "Female",
                Age = 18
            }
        );
}