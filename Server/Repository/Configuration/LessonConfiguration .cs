using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasData
         (
             new Lesson
             {
                 Id = new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"),
                 ModuleId = new Guid("f1a2b3c4-d5e6-4f0a-b9a2-fd1234567890"), // Correct ModuleId
                 Name = "Introduction to Programming",
                 Number = 1,
                 VideoUrl = "https://youtu.be/AWliApDc61w?si=UfwjB-Nuas7Yzpfn",
                 LessonDetails = "This lesson covers the basics of programming.",
                 CourseOrder = 1
             },
             new Lesson
             {
                 Id = new Guid("a2b3c4d5-e6f7-4a8b-b9c2-abcdefabcdef"),
                 ModuleId = new Guid("f1a2b3c4-d5e6-4f0a-b9a2-fd1234567890"), // Correct ModuleId
                 Name = "Variables and Data Types",
                 Number = 2,
                 VideoUrl = "https://youtu.be/ghCbURMWBD8?si=Zr7hm3qOw3H1m0jo",
                 LessonDetails = "In this lesson, we will explore variables and data types.",
                 CourseOrder = 2
             },
             new Lesson
             {
                 Id = new Guid("b3c4d5e6-f7a8-4b0c-b9e0-abcdefabcdef"),
                 ModuleId = new Guid("b2c3d4e5-f6a7-4b0c-b9a2-fd1234567890"), // Correct ModuleId
                 Name = "Control Structures",
                 Number = 3,
                 VideoUrl = "https://youtu.be/eSYeHlwDCNA?si=JABD99_XluZDX3av",
                 LessonDetails = "This lesson focuses on control structures in programming.",
                 CourseOrder = 3
             }
         );
    }
}