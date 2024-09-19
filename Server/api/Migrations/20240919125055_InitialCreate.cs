using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsProgressLimited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CourseOrder = table.Column<int>(type: "int", nullable: false),
                    MinPassScore = table.Column<int>(type: "int", nullable: false),
                    IsPassRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrolments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrolmentDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrolments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrolments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentQuizAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttemptDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScoreAchieved = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuizAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentQuizAttempts_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuizAttempts_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentLessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompletedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLessons_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizAnswers_QuizQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "IsProgressLimited", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"), "Deep dive into modern web development practices and frameworks.", true, "Advanced Web Development", 199.99m },
                    { new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"), "A beginner-friendly course on programming fundamentals.", false, "Introduction to Programming", 99.99m }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e"), "john.doe@example.com", "John", "Doe", "hashedpassword1" },
                    { new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329"), "jane.smith@example.com", "Jane", "Smith", "hashedpassword2" }
                });

            migrationBuilder.InsertData(
                table: "Enrolments",
                columns: new[] { "Id", "CompletedDatetime", "CourseId", "EnrolmentDatetime", "StudentId" },
                values: new object[,]
                {
                    { new Guid("c5a6b7c8-d9e1-4a2b-8e6b-ef1234567890"), null, new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"), new DateTime(2024, 9, 19, 12, 50, 54, 787, DateTimeKind.Utc).AddTicks(8505), new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e") },
                    { new Guid("d1f2a3b4-5678-4c3d-b9e0-abcdefabcdef"), null, new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"), new DateTime(2024, 9, 19, 12, 50, 54, 787, DateTimeKind.Utc).AddTicks(8508), new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329") }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Name", "Number" },
                values: new object[,]
                {
                    { new Guid("b2c3d4e5-f6a7-4b0c-b9a2-fd1234567890"), new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"), "Advanced Programming Concepts", 2 },
                    { new Guid("f1a2b3c4-d5e6-4f0a-b9a2-fd1234567890"), new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"), "Introduction to Programming", 1 }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "CourseId", "CourseOrder", "IsPassRequired", "MinPassScore", "Name", "Number" },
                values: new object[,]
                {
                    { new Guid("a2b3c4d5-e6f7-4a8b-b9c2-fd1234567890"), new Guid("b7f8c9e0-f1e2-4c3d-8f6b-cd9876543210"), 2, true, 80, "Final Exam", 2 },
                    { new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890"), new Guid("e1b2a3c4-d5e6-4f0a-b9a2-fd1234567890"), 1, true, 70, "Midterm Exam", 1 }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseOrder", "LessonDetails", "ModuleId", "Name", "Number", "VideoUrl" },
                values: new object[,]
                {
                    { new Guid("a2b3c4d5-e6f7-4a8b-b9c2-abcdefabcdef"), 2, "In this lesson, we will explore variables and data types.", new Guid("f1a2b3c4-d5e6-4f0a-b9a2-fd1234567890"), "Variables and Data Types", 2, "https://youtu.be/ghCbURMWBD8?si=Zr7hm3qOw3H1m0jo" },
                    { new Guid("b3c4d5e6-f7a8-4b0c-b9e0-abcdefabcdef"), 3, "This lesson focuses on control structures in programming.", new Guid("b2c3d4e5-f6a7-4b0c-b9a2-fd1234567890"), "Control Structures", 3, "https://youtu.be/eSYeHlwDCNA?si=JABD99_XluZDX3av" },
                    { new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"), 1, "This lesson covers the basics of programming.", new Guid("f1a2b3c4-d5e6-4f0a-b9a2-fd1234567890"), "Introduction to Programming", 1, "https://youtu.be/AWliApDc61w?si=UfwjB-Nuas7Yzpfn" }
                });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "QuestionTitle", "QuizId" },
                values: new object[,]
                {
                    { new Guid("a5d6e7f8-90ab-4c2d-b3e4-abcdefabcdef"), "Database Design principles?", new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890") },
                    { new Guid("b7c8d9e0-1f2e-4a3b-b2c3-abcdefabcdef"), "Explain the concept of inheritance in OOP.", new Guid("a2b3c4d5-e6f7-4a8b-b9c2-fd1234567890") },
                    { new Guid("f3c2b1a4-5678-4d9e-b0c1-abcdefabcdef"), "What is the capital of France?", new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890") }
                });

            migrationBuilder.InsertData(
                table: "StudentQuizAttempts",
                columns: new[] { "Id", "AttemptDatetime", "QuizId", "ScoreAchieved", "StudentId" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"), new DateTime(2024, 9, 19, 12, 50, 54, 787, DateTimeKind.Utc).AddTicks(8655), new Guid("d4e5f6a7-b8c9-4d0a-b1c2-fd1234567890"), 85, new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e") },
                    { new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"), new DateTime(2024, 9, 19, 12, 50, 54, 787, DateTimeKind.Utc).AddTicks(8657), new Guid("a2b3c4d5-e6f7-4a8b-b9c2-fd1234567890"), 90, new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329") }
                });

            migrationBuilder.InsertData(
                table: "QuizAnswers",
                columns: new[] { "Id", "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"), "London", false, new Guid("f3c2b1a4-5678-4d9e-b0c1-abcdefabcdef") },
                    { new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"), "4", true, new Guid("a5d6e7f8-90ab-4c2d-b3e4-abcdefabcdef") },
                    { new Guid("c3d4e5f6-78a9-4b0c-b9e0-abcdefabcdef"), "5", false, new Guid("a5d6e7f8-90ab-4c2d-b3e4-abcdefabcdef") },
                    { new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"), "Paris", true, new Guid("f3c2b1a4-5678-4d9e-b0c1-abcdefabcdef") }
                });

            migrationBuilder.InsertData(
                table: "StudentLessons",
                columns: new[] { "Id", "CompletedDatetime", "LessonId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("d1e2f3a4-b5c6-4d7e-a8b9-abcdefabcdef"), new DateTime(2024, 9, 19, 12, 50, 54, 787, DateTimeKind.Utc).AddTicks(8561), new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"), new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e") },
                    { new Guid("f2e3d4c5-b6a7-4e8f-a9b0-abcdefabcdef"), new DateTime(2024, 9, 18, 12, 50, 54, 787, DateTimeKind.Utc).AddTicks(8564), new Guid("e1f2a3b4-c5d6-4e7f-b8a9-abcdefabcdef"), new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_CourseId",
                table: "Enrolments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_StudentId",
                table: "Enrolments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ModuleId",
                table: "Lessons",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseId",
                table: "Modules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswers_QuestionId",
                table: "QuizAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizId",
                table: "QuizQuestions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_CourseId",
                table: "Quizzes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLessons_LessonId",
                table: "StudentLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLessons_StudentId",
                table: "StudentLessons",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuizAttempts_QuizId",
                table: "StudentQuizAttempts",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuizAttempts_StudentId",
                table: "StudentQuizAttempts",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrolments");

            migrationBuilder.DropTable(
                name: "QuizAnswers");

            migrationBuilder.DropTable(
                name: "StudentLessons");

            migrationBuilder.DropTable(
                name: "StudentQuizAttempts");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
