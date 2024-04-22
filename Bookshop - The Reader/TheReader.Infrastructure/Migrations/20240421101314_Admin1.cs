using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class Admin1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "a439f21e-b58a-41e7-9294-ec868774a86a", "AQAAAAEAACcQAAAAEOMNpmtEG6/ooey729zGZHttbBFJcIkOz6a3ejbfa7gAMNRvkl+hCC04NHeCpmhJKQ==", new DateTime(2024, 4, 21, 13, 13, 13, 658, DateTimeKind.Local).AddTicks(7506), "6e888735-57b4-4adc-9479-4fb947f29f81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "f9c4f1a3-1e23-4df5-a38d-2b071f6f412a", "AQAAAAEAACcQAAAAEELJGL4lLIn4ykv4D4WloYDaq5KVg2Tyr4joa7EH9RT0KLaW4sSdv7nbIjCejofP9g==", new DateTime(2024, 4, 21, 13, 13, 13, 660, DateTimeKind.Local).AddTicks(1566), "65410aa2-bef8-445c-ae0f-5b99d12200e3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "f4ee5fa6-43bf-457d-9b45-8389a91b5272", "AQAAAAEAACcQAAAAEJOllowzW2zreQg6RJLBUArx14mRofkq/AUBrE6hVpA5v8Pgt52qVOIoi9ygVJS8Eg==", new DateTime(2024, 4, 21, 13, 9, 44, 217, DateTimeKind.Local).AddTicks(4858), "e2ad30ff-fbb1-4ecd-b388-29c0d3f7c648" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "385018dc-5961-456a-8247-5393c135b9e8", "AQAAAAEAACcQAAAAEOdrlD6eSIWohtrUzYJhZnNq9fYBZzHgwico31N0eYnzziPCbSlcTkkK1YAXBE8kDA==", new DateTime(2024, 4, 21, 13, 9, 44, 218, DateTimeKind.Local).AddTicks(7630), "c7bb49b3-2412-4bf2-917f-5d9c86123192" });
        }
    }
}
