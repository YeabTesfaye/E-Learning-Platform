using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RemovePasswordFromStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("c5a6b7c8-d9e1-4a2b-8e6b-ef1234567890"),
                column: "EnrolmentDatetime",
                value: new DateTime(2024, 9, 26, 7, 12, 51, 825, DateTimeKind.Utc).AddTicks(2702));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("d1f2a3b4-5678-4c3d-b9e0-abcdefabcdef"),
                column: "EnrolmentDatetime",
                value: new DateTime(2024, 9, 26, 7, 12, 51, 825, DateTimeKind.Utc).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-4d7e-a8b9-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 9, 26, 7, 12, 51, 825, DateTimeKind.Utc).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("f2e3d4c5-b6a7-4e8f-a9b0-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 9, 25, 7, 12, 51, 825, DateTimeKind.Utc).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 9, 26, 7, 12, 51, 825, DateTimeKind.Utc).AddTicks(2861));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 9, 26, 7, 12, 51, 825, DateTimeKind.Utc).AddTicks(2864));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("c5a6b7c8-d9e1-4a2b-8e6b-ef1234567890"),
                column: "EnrolmentDatetime",
                value: new DateTime(2024, 9, 26, 6, 28, 3, 682, DateTimeKind.Utc).AddTicks(5247));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("d1f2a3b4-5678-4c3d-b9e0-abcdefabcdef"),
                column: "EnrolmentDatetime",
                value: new DateTime(2024, 9, 26, 6, 28, 3, 682, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-4d7e-a8b9-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 9, 26, 6, 28, 3, 682, DateTimeKind.Utc).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("f2e3d4c5-b6a7-4e8f-a9b0-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 9, 25, 6, 28, 3, 682, DateTimeKind.Utc).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 9, 26, 6, 28, 3, 682, DateTimeKind.Utc).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 9, 26, 6, 28, 3, 682, DateTimeKind.Utc).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("a6f8c3b4-bc6b-4e07-bb0d-bb8f7c6a3c9e"),
                column: "Password",
                value: "hashedpassword1");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("c7babe27-ff5e-4e83-8dfb-2d90c58c7329"),
                column: "Password",
                value: "hashedpassword2");
        }
    }
}
