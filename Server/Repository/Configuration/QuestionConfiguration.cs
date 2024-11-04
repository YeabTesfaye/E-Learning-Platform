using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData
                    (
                        new Question
                        {
                            Id = new Guid("f3c2b1a4-5678-4d9e-b0c1-abcdefabcdef"),
                            QuizId = new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890"), 
                            QuestionTitle = "What is the capital of France?"
                        },
                        new Question
                        {
                            Id = new Guid("a5d6e7f8-90ab-4c2d-b3e4-abcdefabcdef"),
                            QuizId = new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890"), 
                            QuestionTitle = "Database Design principles?"
                        },
                        new Question
                        {
                            Id = new Guid("b7c8d9e0-1f2e-4a3b-b2c3-abcdefabcdef"),
                            QuizId = new Guid("a2b3c4d5-e6f7-4a8b-b9c2-fd1234567890"), 
                            QuestionTitle = "Explain the concept of inheritance in OOP."
                        }
                    );
        }
    }
}