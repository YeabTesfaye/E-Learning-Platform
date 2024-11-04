using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasData
               (
                   new Quiz
                   {
                       Id = new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890"),
                       CourseId = new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"), 
                       Name = "Midterm Exam",
                       Number = 1,
                       CourseOrder = 1,
                       PassingScore = 70,
                       IsPassRequired = true,
                       MaxAttempts = 5
                   },
                   new Quiz
                   {
                       Id = new Guid("a2b3c4d5-e6f7-4a8b-b9c2-fd1234567890"),
                       CourseId = new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"), 
                       Name = "Final Exam",
                       Number = 2,
                       CourseOrder = 2,
                       PassingScore = 80,
                       IsPassRequired = true,
                       MaxAttempts = 5
                   }
               );
    }
}