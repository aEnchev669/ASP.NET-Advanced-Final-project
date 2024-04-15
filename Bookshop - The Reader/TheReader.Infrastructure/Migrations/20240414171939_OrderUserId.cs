using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class OrderUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "0a3a716f-74fe-45a8-8463-65172e3cb28f", "AQAAAAEAACcQAAAAELiGBANwIdzOFpXouFrxcW154Xdf6d+1EOn6NgNZ5mkSXLcSZnJR6T04O4fO9xCnAQ==", new DateTime(2024, 4, 14, 17, 50, 7, 930, DateTimeKind.Local).AddTicks(7011), "f36c7c48-b85b-484c-9543-08579645c57b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 4, 14, 17, 50, 7, 931, DateTimeKind.Local).AddTicks(9526), "9a9b4771-5184-488f-a7fb-58cff482eb47", "AQAAAAEAACcQAAAAEEISS1BhUdwCG06CP5esTL8Lq8OImVaHg919NcDl6GP0HRA/daKTmBR7K0guOLL5Uw==", new DateTime(2024, 4, 14, 17, 50, 7, 931, DateTimeKind.Local).AddTicks(9517), "60c4d364-b7b4-4e6f-a547-ac878367d7c3" });
        }
    }
}
