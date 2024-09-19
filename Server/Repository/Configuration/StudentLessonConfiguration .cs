using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class StudentLessonConfiguration : IEntityTypeConfiguration<StudentLesson>
{
    public void Configure(EntityTypeBuilder<StudentLesson> builder)
    {
        builder.HasData
               (
                   new StudentLesson
                   {
                       Id = new Guid("d1e2f3a4-b5c6-4d7e-a8b9-abcdefabcdef"),
                       StudentId = new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e"), 
                       LessonId = new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"), 
                       CompletedDatetime = DateTime.UtcNow
                   },
                   new StudentLesson
                   {
                       Id = new Guid("f2e3d4c5-b6a7-4e8f-a9b0-abcdefabcdef"),
                       StudentId = new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329"), 
                       LessonId = new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"), 
                       CompletedDatetime = DateTime.UtcNow.AddDays(-1) // Completed yesterday
                   }
               );
    }
}