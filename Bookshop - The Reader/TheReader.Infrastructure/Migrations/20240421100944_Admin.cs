using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "385018dc-5961-456a-8247-5393c135b9e8", "AQAAAAEAACcQAAAAEOdrlD6eSIWohtrUzYJhZnNq9fYBZzHgwico31N0eYnzziPCbSlcTkkK1YAXBE8kDA==", new DateTime(2024, 4, 21, 13, 9, 44, 218, DateTimeKind.Local).AddTicks(7630), "c7bb49b3-2412-4bf2-917f-5d9c86123192" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93", 0, null, "f4ee5fa6-43bf-457d-9b45-8389a91b5272", "Admin@gmail.com", false, "Admin", 1, false, "Adminov", false, null, "ADMIN@gmail.com", "ADMIN231", "AQAAAAEAACcQAAAAEJOllowzW2zreQg6RJLBUArx14mRofkq/AUBrE6hVpA5v8Pgt52qVOIoi9ygVJS8Eg==", null, false, new DateTime(2024, 4, 21, 13, 9, 44, 217, DateTimeKind.Local).AddTicks(4858), "e2ad30ff-fbb1-4ecd-b388-29c0d3f7c648", false, "admin231" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "eecbaddd-783c-45e9-88b9-19bf3bc72588", "AQAAAAEAACcQAAAAEFNoLKPHf05LWPl3OQxcourj657zI+bMx9KMGIxTn4NFHiLNFZ4DgodF1cjB9K2oWg==", new DateTime(2024, 4, 21, 13, 6, 38, 532, DateTimeKind.Local).AddTicks(8589), "6ebb9ac1-298a-48a5-9827-83c58b742ff8" });
        }
    }
}
