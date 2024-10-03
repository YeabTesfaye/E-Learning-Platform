using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44b87adc-5708-4114-8741-30ff7319fef1", null, "Instructor", "INSTRUCTOR" },
                    { "90b5715c-f3d3-49b3-b6a8-97191bca2f1c", null, "Administrator", "ADMINISTRATOR" },
                    { "c176df6b-08e6-452b-b86b-364aca8db27c", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("c5a6b7c8-d9e1-4a2b-8e6b-ef1234567890"),
                column: "EnrolmentDatetime",
                value: new DateTime(2024, 10, 2, 18, 44, 47, 603, DateTimeKind.Utc).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("d1f2a3b4-5678-4c3d-b9e0-abcdefabcdef"),
                column: "EnrolmentDatetime",
                value: new DateTime(2024, 10, 2, 18, 44, 47, 603, DateTimeKind.Utc).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-4d7e-a8b9-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 10, 2, 18, 44, 47, 603, DateTimeKind.Utc).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("f2e3d4c5-b6a7-4e8f-a9b0-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 10, 1, 18, 44, 47, 603, DateTimeKind.Utc).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 10, 2, 18, 44, 47, 603, DateTimeKind.Utc).AddTicks(2639));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 10, 2, 18, 44, 47, 603, DateTimeKind.Utc).AddTicks(2655));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44b87adc-5708-4114-8741-30ff7319fef1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90b5715c-f3d3-49b3-b6a8-97191bca2f1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c176df6b-08e6-452b-b86b-364aca8db27c");

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("c5a6b7c8-d9e1-4a2b-8e6b-ef1234567890"),
                column: "EnrolmentDatetime",
                value: new DateTime(2024, 10, 2, 18, 29, 32, 676, DateTimeKind.Utc).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("d1f2a3b4-5678-4c3d-b9e0-abcdefabcdef"),
                column: "EnrolmentDatetime",
                value: new DateTime(2024, 10, 2, 18, 29, 32, 676, DateTimeKind.Utc).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-4d7e-a8b9-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 10, 2, 18, 29, 32, 676, DateTimeKind.Utc).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("f2e3d4c5-b6a7-4e8f-a9b0-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 10, 1, 18, 29, 32, 676, DateTimeKind.Utc).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 10, 2, 18, 29, 32, 676, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 10, 2, 18, 29, 32, 676, DateTimeKind.Utc).AddTicks(3097));
        }
    }
}
