using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("8d6a9f34-1f6b-4f1b-bb20-38b75f56d9d5"), "michael.brown@example.com", "Michael", "Brown" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("d9d8cfcf-459d-4d7e-8f21-c0f0badd77cb"), "bob.williams@example.com", "Bob", "Williams" },
                    { new Guid("e8e8cfcf-349d-4d7e-9f30-c0f0badd55ab"), "alice.johnson@example.com", "Alice", "Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Credits", "Description", "InstructorId", "Title" },
                values: new object[,]
                {
                    { new Guid("a56d8b60-2f4d-4b77-8f6d-bd2a5ab7c345"), 3, "An introductory course on programming basics.", new Guid("8d6a9f34-1f6b-4f1b-bb20-38b75f56d9d5"), "Fundamentals of Programming" },
                    { new Guid("b65d8b60-2f4d-4b77-8f6d-cd2a5ab7c345"), 4, "An advanced course covering database management systems.", new Guid("8d6a9f34-1f6b-4f1b-bb20-38b75f56d9d5"), "Advanced Database Systems" }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "CertificateId", "CertificateCode", "CourseId", "IssuedDate", "StudentId" },
                values: new object[,]
                {
                    { new Guid("d76b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"), "CERT12345", new Guid("a56d8b60-2f4d-4b77-8f6d-bd2a5ab7c345"), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8e8cfcf-349d-4d7e-9f30-c0f0badd55ab") },
                    { new Guid("e86b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"), "CERT67890", new Guid("b65d8b60-2f4d-4b77-8f6d-cd2a5ab7c345"), new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d9d8cfcf-459d-4d7e-8f21-c0f0badd77cb") }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "Content", "CourseId", "Title" },
                values: new object[,]
                {
                    { new Guid("c56b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"), "Basic concepts of C# programming language.", new Guid("a56d8b60-2f4d-4b77-8f6d-bd2a5ab7c345"), "Introduction to C#" },
                    { new Guid("d65b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"), "Fundamentals of database design and normalization.", new Guid("b65d8b60-2f4d-4b77-8f6d-cd2a5ab7c345"), "Database Design" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "CertificateId",
                keyValue: new Guid("d76b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "CertificateId",
                keyValue: new Guid("e86b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: new Guid("c56b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: new Guid("d65b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("a56d8b60-2f4d-4b77-8f6d-bd2a5ab7c345"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("b65d8b60-2f4d-4b77-8f6d-cd2a5ab7c345"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("d9d8cfcf-459d-4d7e-8f21-c0f0badd77cb"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("e8e8cfcf-349d-4d7e-9f30-c0f0badd55ab"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("8d6a9f34-1f6b-4f1b-bb20-38b75f56d9d5"));

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Courses");
        }
    }
}
