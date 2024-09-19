using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class QuizAnswerConfiguration : IEntityTypeConfiguration<QuizAnswer>
    {
        public void Configure(EntityTypeBuilder<QuizAnswer> builder)
        {
           builder.HasData
        (
            new QuizAnswer
            {
                Id = new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"),
                QuestionId = new Guid("f3c2b1a4-5678-4d9e-b0c1-abcdefabcdef"), 
                AnswerText = "Paris",
                IsCorrect = true
            },
            new QuizAnswer
            {
                Id = new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                QuestionId = new Guid("f3c2b1a4-5678-4d9e-b0c1-abcdefabcdef"), 
                AnswerText = "London",
                IsCorrect = false
            },
            new QuizAnswer
            {
                Id = new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                QuestionId = new Guid("a5d6e7f8-90ab-4c2d-b3e4-abcdefabcdef"), 
                AnswerText = "4",
                IsCorrect = true
            },
            new QuizAnswer
            {
                Id = new Guid("c3d4e5f6-78a9-4b0c-b9e0-abcdefabcdef"),
                QuestionId = new Guid("a5d6e7f8-90ab-4c2d-b3e4-abcdefabcdef"), 
                AnswerText = "5",
                IsCorrect = false
            }
        );
        }
    }
}