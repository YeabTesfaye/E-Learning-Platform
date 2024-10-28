using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CreatingIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
    }
}
