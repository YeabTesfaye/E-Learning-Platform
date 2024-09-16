using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student
                {
                    StudentId = new Guid("e8e8cfcf-349d-4d7e-9f30-c0f0badd55ab"),
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@example.com"
                },
                new Student
                {
                    StudentId = new Guid("d9d8cfcf-459d-4d7e-8f21-c0f0badd77cb"),
                    FirstName = "Bob",
                    LastName = "Williams",
                    Email = "bob.williams@example.com"
                }
            );
        }
    }
}
