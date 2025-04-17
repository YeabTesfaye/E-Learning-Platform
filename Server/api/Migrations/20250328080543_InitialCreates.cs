using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16c1efd8-afdd-43e4-92a8-eeec79016072");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2938f39-51ea-490f-ac3b-fddd78f2e17f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d72a3b73-726f-44f5-bcd1-a1fecf5a19f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10020b39-6983-4e7d-9b10-f90024f020a3", null, "Instructor", "INSTRUCTOR" },
                    { "6a07c8b3-9d82-41c9-aeb8-5d2a50c98c4c", null, "Administrator", "ADMINISTRATOR" },
                    { "89eb8a48-89b4-4800-a383-54d17dfb1484", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("c5a6b7c8-d9e1-4a2b-8e6b-ef1234567890"),
                columns: new[] { "CompletedDatetime", "EnrolmentDatetime" },
                values: new object[] { new DateTime(2025, 3, 28, 11, 5, 43, 66, DateTimeKind.Local).AddTicks(5619), new DateTime(2025, 3, 28, 8, 5, 43, 66, DateTimeKind.Utc).AddTicks(5616) });

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("d1f2a3b4-5678-4c3d-b9e0-abcdefabcdef"),
                columns: new[] { "CompletedDatetime", "EnrolmentDatetime" },
                values: new object[] { new DateTime(2025, 3, 28, 11, 5, 43, 66, DateTimeKind.Local).AddTicks(5630), new DateTime(2025, 3, 28, 8, 5, 43, 66, DateTimeKind.Utc).AddTicks(5629) });

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2025, 3, 28, 8, 5, 43, 66, DateTimeKind.Utc).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2025, 3, 28, 8, 5, 43, 66, DateTimeKind.Utc).AddTicks(5774));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-4d7e-a8b9-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2025, 3, 28, 8, 5, 43, 66, DateTimeKind.Utc).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("f2e3d4c5-b6a7-4e8f-a9b0-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2025, 3, 27, 8, 5, 43, 66, DateTimeKind.Utc).AddTicks(5698));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10020b39-6983-4e7d-9b10-f90024f020a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a07c8b3-9d82-41c9-aeb8-5d2a50c98c4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89eb8a48-89b4-4800-a383-54d17dfb1484");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16c1efd8-afdd-43e4-92a8-eeec79016072", null, "Administrator", "ADMINISTRATOR" },
                    { "b2938f39-51ea-490f-ac3b-fddd78f2e17f", null, "Instructor", "INSTRUCTOR" },
                    { "d72a3b73-726f-44f5-bcd1-a1fecf5a19f9", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("c5a6b7c8-d9e1-4a2b-8e6b-ef1234567890"),
                columns: new[] { "CompletedDatetime", "EnrolmentDatetime" },
                values: new object[] { new DateTime(2024, 11, 4, 16, 10, 43, 114, DateTimeKind.Local).AddTicks(8989), new DateTime(2024, 11, 4, 13, 10, 43, 114, DateTimeKind.Utc).AddTicks(8982) });

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("d1f2a3b4-5678-4c3d-b9e0-abcdefabcdef"),
                columns: new[] { "CompletedDatetime", "EnrolmentDatetime" },
                values: new object[] { new DateTime(2024, 11, 4, 16, 10, 43, 114, DateTimeKind.Local).AddTicks(9001), new DateTime(2024, 11, 4, 13, 10, 43, 114, DateTimeKind.Utc).AddTicks(9001) });

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 11, 4, 13, 10, 43, 114, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "QuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 11, 4, 13, 10, 43, 114, DateTimeKind.Utc).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-4d7e-a8b9-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 11, 4, 13, 10, 43, 114, DateTimeKind.Utc).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("f2e3d4c5-b6a7-4e8f-a9b0-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 11, 3, 13, 10, 43, 114, DateTimeKind.Utc).AddTicks(9066));
        }
    }
}
