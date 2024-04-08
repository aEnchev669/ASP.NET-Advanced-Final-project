using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class NewUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_ApplicationUsers_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ApplicationUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProducts_ApplicationUsers_ApplicationUserId",
                table: "UsersProducts");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                comment: "Current user");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                comment: "The birth date of the current user");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                comment: "The first name of the current user");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                comment: "The genre of the current user");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                comment: "Is the user deleten");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                comment: "The last name of the current user");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                comment: "The registration date of the current user");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93", 0, null, "bb713dc1-2eeb-4a48-8382-387778308ba7", "ApplicationUser", "Admin@gmail.com", false, "Admin", 0, false, "Adminov", false, null, "ADMIN@gmail.com", "ADMIN231", "AQAAAAEAACcQAAAAEAyhr8S/YvSYS1HSjpQxPJa/YCOypzxf06vgat/vV/Hmqm3MpE0V5Uuqts+TU0UFBA==", null, false, new DateTime(2024, 4, 8, 17, 1, 36, 275, DateTimeKind.Local).AddTicks(6058), "16de10a4-ea9e-4e4f-88ef-abc275d1ef23", false, "admin231" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "641ca250-7c7a-40a5-8e3c-657714fb3d4a", 0, new DateTime(2024, 4, 8, 17, 1, 36, 276, DateTimeKind.Local).AddTicks(9889), "8aa05387-ef79-4b52-9248-cca1a3fd6f12", "ApplicationUser", "guest231@gmail.com", false, "Guest", 1, false, "Guestov", false, null, "GUEST231@gmail.com", "GUEST231", "AQAAAAEAACcQAAAAEDAmbF5QsLZCHI67skf7jhw55uvsq5dpyJUhgSFXAqODpy6eouEIDVmpD2Nv46UtXA==", null, false, new DateTime(2024, 4, 8, 17, 1, 36, 276, DateTimeKind.Local).AddTicks(9870), "b4bc2c5e-4da5-4cf3-bf94-5949f9287cbc", false, "Guest231" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProducts_AspNetUsers_ApplicationUserId",
                table: "UsersProducts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProducts_AspNetUsers_ApplicationUserId",
                table: "UsersProducts");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "AspNetUsers");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                oldComment: "Current user");

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "The birth date of the current user"),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "The first name of the current user"),
                    Gender = table.Column<int>(type: "int", nullable: false, comment: "The genre of the current user"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Is the user deleten"),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "The last name of the current user"),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The registration date of the current user"),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                },
                comment: "Current user");

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93", 0, null, "2b54cc06-c4bf-425d-8fa8-aa194f8222e6", "Admin@gmail.com", false, "Admin", 0, false, "Adminov", false, null, "ADMIN@gmail.com", "ADMIN231", "AQAAAAEAACcQAAAAEJYiaMQfnpk3zlW76BUrKguslAdZ5tB1C/gfa24ebE2NhWgxdLVfIRRbU0oZ5cL9IA==", null, false, new DateTime(2024, 4, 8, 11, 26, 17, 874, DateTimeKind.Local).AddTicks(6247), null, false, "admin231" });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "641ca250-7c7a-40a5-8e3c-657714fb3d4a", 0, new DateTime(2024, 4, 8, 11, 26, 17, 875, DateTimeKind.Local).AddTicks(9757), "12955423-fcf1-4d3b-b677-3f3634cff3a2", "guest231@gmail.com", false, "Guest", 1, false, "Guestov", false, null, "GUEST231@gmail.com", "GUEST231", "AQAAAAEAACcQAAAAEMx/TG6Bfyl67is44hDLplpkhFAOAtn3FlSZbfsRP0EbXCXavMhsUmEhA+3KudLDUA==", null, false, new DateTime(2024, 4, 8, 11, 26, 17, 875, DateTimeKind.Local).AddTicks(9752), null, false, "Guest231" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_ApplicationUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ApplicationUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProducts_ApplicationUsers_ApplicationUserId",
                table: "UsersProducts",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
