﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"),
                            AnswerText = "Paris",
                            IsCorrect = true,
                            QuestionId = new Guid("f3c2b1a4-5678-4d9e-b0c1-abcdefabcdef")
                        },
                        new
                        {
                            Id = new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                            AnswerText = "London",
                            IsCorrect = false,
                            QuestionId = new Guid("f3c2b1a4-5678-4d9e-b0c1-abcdefabcdef")
                        },
                        new
                        {
                            Id = new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                            AnswerText = "4",
                            IsCorrect = true,
                            QuestionId = new Guid("a5d6e7f8-90ab-4c2d-b3e4-abcdefabcdef")
                        },
                        new
                        {
                            Id = new Guid("c3d4e5f6-78a9-4b0c-b9e0-abcdefabcdef"),
                            AnswerText = "5",
                            IsCorrect = false,
                            QuestionId = new Guid("a5d6e7f8-90ab-4c2d-b3e4-abcdefabcdef")
                        });
                });

            modelBuilder.Entity("Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"),
                            Description = "A beginner-friendly course on programming fundamentals.",
                            Name = "Introduction to Programming",
                            Price = 99.99m
                        },
                        new
                        {
                            Id = new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"),
                            Description = "Deep dive into modern web development practices and frameworks.",
                            Name = "Advanced Web Development",
                            Price = 199.99m
                        });
                });

            modelBuilder.Entity("Entities.Enrolment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CompletedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EnrolmentDatetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrolments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c5a6b7c8-d9e1-4a2b-8e6b-ef1234567890"),
                            CompletedDatetime = new DateTime(2024, 11, 2, 18, 37, 31, 857, DateTimeKind.Local).AddTicks(9043),
                            CourseId = new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"),
                            EnrolmentDatetime = new DateTime(2024, 11, 2, 15, 37, 31, 857, DateTimeKind.Utc).AddTicks(9035),
                            Status = 0,
                            StudentId = new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e")
                        },
                        new
                        {
                            Id = new Guid("d1f2a3b4-5678-4c3d-b9e0-abcdefabcdef"),
                            CompletedDatetime = new DateTime(2024, 11, 2, 18, 37, 31, 857, DateTimeKind.Local).AddTicks(9095),
                            CourseId = new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"),
                            EnrolmentDatetime = new DateTime(2024, 11, 2, 15, 37, 31, 857, DateTimeKind.Utc).AddTicks(9094),
                            Status = 0,
                            StudentId = new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329")
                        });
                });

            modelBuilder.Entity("Entities.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CourseOrder")
                        .HasColumnType("int");

                    b.Property<string>("LessonDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"),
                            CourseOrder = 1,
                            LessonDetails = "This lesson covers the basics of programming.",
                            ModuleId = new Guid("f1a2b3c4-d5e6-4f0a-b9a2-fd1234567890"),
                            Name = "Introduction to Programming",
                            Number = 1,
                            VideoUrl = "https://youtu.be/AWliApDc61w?si=UfwjB-Nuas7Yzpfn"
                        },
                        new
                        {
                            Id = new Guid("a2b3c4d5-e6f7-4a8b-b9c2-abcdefabcdef"),
                            CourseOrder = 2,
                            LessonDetails = "In this lesson, we will explore variables and data types.",
                            ModuleId = new Guid("f1a2b3c4-d5e6-4f0a-b9a2-fd1234567890"),
                            Name = "Variables and Data Types",
                            Number = 2,
                            VideoUrl = "https://youtu.be/ghCbURMWBD8?si=Zr7hm3qOw3H1m0jo"
                        },
                        new
                        {
                            Id = new Guid("b3c4d5e6-f7a8-4b0c-b9e0-abcdefabcdef"),
                            CourseOrder = 3,
                            LessonDetails = "This lesson focuses on control structures in programming.",
                            ModuleId = new Guid("b2c3d4e5-f6a7-4b0c-b9a2-fd1234567890"),
                            Name = "Control Structures",
                            Number = 3,
                            VideoUrl = "https://youtu.be/eSYeHlwDCNA?si=JABD99_XluZDX3av"
                        });
                });

            modelBuilder.Entity("Entities.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Modules");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f1a2b3c4-d5e6-4f0a-b9a2-fd1234567890"),
                            CourseId = new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"),
                            Name = "Introduction to Programming",
                            Number = 1
                        },
                        new
                        {
                            Id = new Guid("b2c3d4e5-f6a7-4b0c-b9a2-fd1234567890"),
                            CourseId = new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"),
                            Name = "Advanced Programming Concepts",
                            Number = 2
                        });
                });

            modelBuilder.Entity("Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QuestionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f3c2b1a4-5678-4d9e-b0c1-abcdefabcdef"),
                            QuestionTitle = "What is the capital of France?",
                            QuizId = new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890")
                        },
                        new
                        {
                            Id = new Guid("a5d6e7f8-90ab-4c2d-b3e4-abcdefabcdef"),
                            QuestionTitle = "Database Design principles?",
                            QuizId = new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890")
                        },
                        new
                        {
                            Id = new Guid("b7c8d9e0-1f2e-4a3b-b2c3-abcdefabcdef"),
                            QuestionTitle = "Explain the concept of inheritance in OOP.",
                            QuizId = new Guid("a2b3c4d5-e6f7-4a8b-b9c2-fd1234567890")
                        });
                });

            modelBuilder.Entity("Entities.Quiz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CourseOrder")
                        .HasColumnType("int");

                    b.Property<bool>("IsPassRequired")
                        .HasColumnType("bit");

                    b.Property<int>("MaxAttempts")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PassingScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890"),
                            CourseId = new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"),
                            CourseOrder = 1,
                            IsPassRequired = true,
                            MaxAttempts = 5,
                            Name = "Midterm Exam",
                            Number = 1,
                            PassingScore = 70
                        },
                        new
                        {
                            Id = new Guid("a2b3c4d5-e6f7-4a8b-b9c2-fd1234567890"),
                            CourseId = new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"),
                            CourseOrder = 2,
                            IsPassRequired = true,
                            MaxAttempts = 5,
                            Name = "Final Exam",
                            Number = 2,
                            PassingScore = 80
                        });
                });

            modelBuilder.Entity("Entities.QuizAttempt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AttemptDatetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("AttemptNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ScoreAchieved")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.HasIndex("StudentId");

                    b.ToTable("QuizAttempts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                            AttemptDatetime = new DateTime(2024, 11, 2, 15, 37, 31, 858, DateTimeKind.Utc).AddTicks(67),
                            AttemptNumber = 0,
                            QuizId = new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890"),
                            ScoreAchieved = 85,
                            StudentId = new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e")
                        },
                        new
                        {
                            Id = new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                            AttemptDatetime = new DateTime(2024, 11, 2, 15, 37, 31, 858, DateTimeKind.Utc).AddTicks(77),
                            AttemptNumber = 0,
                            QuizId = new Guid("a2b3c4d5-e6f7-4a8b-b9c2-fd1234567890"),
                            ScoreAchieved = 90,
                            StudentId = new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329")
                        });
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e"),
                            Age = 25,
                            EmailAddress = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Sex = "Male"
                        },
                        new
                        {
                            Id = new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329"),
                            Age = 18,
                            EmailAddress = "jane.smith@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            Sex = "Female"
                        });
                });

            modelBuilder.Entity("Entities.StudentLesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CompletedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Progress")
                        .HasColumnType("bit");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentLessons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1e2f3a4-b5c6-4d7e-a8b9-abcdefabcdef"),
                            CompletedDatetime = new DateTime(2024, 11, 2, 15, 37, 31, 857, DateTimeKind.Utc).AddTicks(9377),
                            LessonId = new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"),
                            Progress = false,
                            StudentId = new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e")
                        },
                        new
                        {
                            Id = new Guid("f2e3d4c5-b6a7-4e8f-a9b0-abcdefabcdef"),
                            CompletedDatetime = new DateTime(2024, 11, 1, 15, 37, 31, 857, DateTimeKind.Utc).AddTicks(9385),
                            LessonId = new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"),
                            Progress = false,
                            StudentId = new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329")
                        });
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "f266e866-cfd8-47e7-89cb-6b8e54608951",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "b11c8df2-397d-434c-8217-a34813c0921a",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "422fd89e-03cc-482f-b17a-b60a1a1e41d3",
                            Name = "Instructor",
                            NormalizedName = "INSTRUCTOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Answer", b =>
                {
                    b.HasOne("Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Entities.Enrolment", b =>
                {
                    b.HasOne("Entities.Course", "Course")
                        .WithMany("Enrolments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Student", "Student")
                        .WithMany("Enrolments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Entities.Lesson", b =>
                {
                    b.HasOne("Entities.Module", "Module")
                        .WithMany("Lessons")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("Entities.Module", b =>
                {
                    b.HasOne("Entities.Course", "Course")
                        .WithMany("Modules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Entities.Question", b =>
                {
                    b.HasOne("Entities.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Entities.Quiz", b =>
                {
                    b.HasOne("Entities.Course", "Course")
                        .WithMany("Quizzes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Entities.QuizAttempt", b =>
                {
                    b.HasOne("Entities.Quiz", "Quiz")
                        .WithMany("Attempts")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Student", "Student")
                        .WithMany("QuizAttempts")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Entities.StudentLesson", b =>
                {
                    b.HasOne("Entities.Lesson", "Lesson")
                        .WithMany("StudentLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Student", "Student")
                        .WithMany("StudentLessons")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Course", b =>
                {
                    b.Navigation("Enrolments");

                    b.Navigation("Modules");

                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("Entities.Lesson", b =>
                {
                    b.Navigation("StudentLessons");
                });

            modelBuilder.Entity("Entities.Module", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Entities.Quiz", b =>
                {
                    b.Navigation("Attempts");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.Navigation("Enrolments");

                    b.Navigation("QuizAttempts");

                    b.Navigation("StudentLessons");
                });
#pragma warning restore 612, 618
        }
    }
}
