using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasData(
            new Instructor
            {
                InstructorId = new Guid("8d6a9f34-1f6b-4f1b-bb20-38b75f56d9d5"),
                FirstName = "Michael",
                LastName = "Brown",
                Email = "michael.brown@example.com"
            }
        );
    }
}
