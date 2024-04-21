using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "e002d2b4-710c-48eb-9951-6a579830182d", "AQAAAAEAACcQAAAAEOKxpyfeWAe+rxGtllnxWRzMR0g48xrbpY1PbBGcEhM5LeOW1SUWMg7okqjWJ9zMdA==", new DateTime(2024, 4, 20, 7, 59, 12, 492, DateTimeKind.Local).AddTicks(332), "43294194-fe67-4858-a5d4-33e7d3ed9287" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 4, 20, 7, 59, 12, 493, DateTimeKind.Local).AddTicks(2873), "f261e958-2bed-4233-a40a-23c45d775ac7", "AQAAAAEAACcQAAAAEG8l3LA0M8DyyyvZXgiqjOj4Y8WlizNxei7x/Om97glw/YwouCIt0HTWvKxkF98fvA==", new DateTime(2024, 4, 20, 7, 59, 12, 493, DateTimeKind.Local).AddTicks(2866), "4d5b4783-da01-49d5-abbf-e4f286ad8f3c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Current comment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "Book identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date of creation of the current comemnt"),
                    Text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Current comment text")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Current Comment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "7c9ed8e9-5793-4973-95eb-203f71aa40b5", "AQAAAAEAACcQAAAAEPm3QC0XRL5pwR9WEA3LFDRK4lRZJ2JfaDKX7/kxo29/+Cc8WrQYW3xJswVRBwsyKg==", new DateTime(2024, 4, 14, 20, 19, 38, 733, DateTimeKind.Local).AddTicks(957), "417d21a9-5c76-4ae4-b5a4-b5d801d7d65c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 4, 14, 20, 19, 38, 734, DateTimeKind.Local).AddTicks(3527), "c9338d85-0390-45dd-9c41-b2c9c3930c41", "AQAAAAEAACcQAAAAED0nCrxmMKWDDUJoNTIwusY9OoGCsauV6dsxrllHTdRUiqrCoRcYGec3WqkWD2vk2w==", new DateTime(2024, 4, 14, 20, 19, 38, 734, DateTimeKind.Local).AddTicks(3519), "6b041b8f-0b1f-427a-b005-187b906bff62" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }
    }
}
