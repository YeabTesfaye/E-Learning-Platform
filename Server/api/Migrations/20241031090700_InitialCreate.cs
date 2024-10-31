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
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d3d4211-0e88-4ca5-86c2-defb92fe1484");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "682a03a1-e2d3-4748-893a-dff47d52a049");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69cae8ac-18f4-4fce-88c2-2b81bbdbc9ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2de25be7-6038-4fd8-8e4c-9e635daf93fa", null, "Instructor", "INSTRUCTOR" },
                    { "80ab6450-31d2-4811-8a10-052035416e57", null, "Manager", "MANAGER" },
                    { "ec4f805a-e260-43ed-9439-b45c17ca1952", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("c5a6b7c8-d9e1-4a2b-8e6b-ef1234567890"),
                columns: new[] { "CompletedDatetime", "EnrolmentDatetime" },
                values: new object[] { new DateTime(2024, 10, 31, 12, 7, 0, 534, DateTimeKind.Local).AddTicks(9151), new DateTime(2024, 10, 31, 9, 7, 0, 534, DateTimeKind.Utc).AddTicks(9143) });

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("d1f2a3b4-5678-4c3d-b9e0-abcdefabcdef"),
                columns: new[] { "CompletedDatetime", "EnrolmentDatetime" },
                values: new object[] { new DateTime(2024, 10, 31, 12, 7, 0, 534, DateTimeKind.Local).AddTicks(9162), new DateTime(2024, 10, 31, 9, 7, 0, 534, DateTimeKind.Utc).AddTicks(9161) });

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-4d7e-a8b9-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 10, 31, 9, 7, 0, 534, DateTimeKind.Utc).AddTicks(9227));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("f2e3d4c5-b6a7-4e8f-a9b0-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 10, 30, 9, 7, 0, 534, DateTimeKind.Utc).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 10, 31, 9, 7, 0, 534, DateTimeKind.Utc).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 10, 31, 9, 7, 0, 534, DateTimeKind.Utc).AddTicks(9309));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2de25be7-6038-4fd8-8e4c-9e635daf93fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80ab6450-31d2-4811-8a10-052035416e57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec4f805a-e260-43ed-9439-b45c17ca1952");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d3d4211-0e88-4ca5-86c2-defb92fe1484", null, "Instructor", "INSTRUCTOR" },
                    { "682a03a1-e2d3-4748-893a-dff47d52a049", null, "Manager", "MANAGER" },
                    { "69cae8ac-18f4-4fce-88c2-2b81bbdbc9ff", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("c5a6b7c8-d9e1-4a2b-8e6b-ef1234567890"),
                columns: new[] { "CompletedDatetime", "EnrolmentDatetime" },
                values: new object[] { new DateTime(2024, 10, 30, 16, 50, 19, 32, DateTimeKind.Local).AddTicks(1682), new DateTime(2024, 10, 30, 13, 50, 19, 32, DateTimeKind.Utc).AddTicks(1676) });

            migrationBuilder.UpdateData(
                table: "Enrolments",
                keyColumn: "Id",
                keyValue: new Guid("d1f2a3b4-5678-4c3d-b9e0-abcdefabcdef"),
                columns: new[] { "CompletedDatetime", "EnrolmentDatetime" },
                values: new object[] { new DateTime(2024, 10, 30, 16, 50, 19, 32, DateTimeKind.Local).AddTicks(1694), new DateTime(2024, 10, 30, 13, 50, 19, 32, DateTimeKind.Utc).AddTicks(1694) });

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-4d7e-a8b9-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 10, 30, 13, 50, 19, 32, DateTimeKind.Utc).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "StudentLessons",
                keyColumn: "Id",
                keyValue: new Guid("f2e3d4c5-b6a7-4e8f-a9b0-abcdefabcdef"),
                column: "CompletedDatetime",
                value: new DateTime(2024, 10, 29, 13, 50, 19, 32, DateTimeKind.Utc).AddTicks(1762));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a2b-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 10, 30, 13, 50, 19, 32, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "StudentQuizAttempts",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b0c-b9e0-abcdefabcdef"),
                column: "AttemptDatetime",
                value: new DateTime(2024, 10, 30, 13, 50, 19, 32, DateTimeKind.Utc).AddTicks(1880));
        }
    }
}
