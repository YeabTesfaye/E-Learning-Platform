using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class StudentQuizAttemptConfiguration : IEntityTypeConfiguration<StudentQuizAttempt>
{
    public void Configure(EntityTypeBuilder<StudentQuizAttempt> builder)
    {
        builder.HasData
                (
                    new StudentQuizAttempt
                    {
                        Id = new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                        StudentId = new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e"), 
                        QuizId = new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890"), 
                        AttemptDatetime = DateTime.UtcNow,
                        ScoreAchieved = 85
                    },
                    new StudentQuizAttempt
                    {
                        Id = new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                        StudentId = new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329"), 
                        QuizId = new Guid("a2b3c4d5-e6f7-4a8b-b9c2-fd1234567890"), 
                        AttemptDatetime = DateTime.UtcNow,
                        ScoreAchieved = 90
                    }
                );
    }
}