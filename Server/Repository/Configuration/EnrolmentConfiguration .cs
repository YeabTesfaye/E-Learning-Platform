using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class EnrolmentConfiguration : IEntityTypeConfiguration<Enrolment>
    {
        public void Configure(EntityTypeBuilder<Enrolment> builder)
        {
            builder.HasData
        (
            new Enrolment
            {
                Id = new Guid("c5a6b7c8-d9e1-4a2b-8e6b-ef1234567890"),
                CourseId = new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"), // Example CourseId
                StudentId = new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e"), // Example StudentId
                EnrolmentDatetime = DateTime.UtcNow,
                CompletedDatetime = null // Or set to a specific date if completed
            },
            new Enrolment
            {
                Id = new Guid("d1f2a3b4-5678-4c3d-b9e0-abcdefabcdef"),
                CourseId = new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"), // Example CourseId
                StudentId = new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329"), // Example StudentId
                EnrolmentDatetime = DateTime.UtcNow,
                CompletedDatetime = null // Or set to a specific date if completed
            }
        );
        }
    }
}