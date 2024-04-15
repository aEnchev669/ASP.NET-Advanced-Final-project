using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class CartCreatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "d67c099e-1dd1-4a8e-85c2-e133b99005ee", "AQAAAAEAACcQAAAAEBkPfuLub7vigkYrndwGzf4I/MsnMMnDSbRcNmuNw0QP8FgMva+c7ok/aEq9zg6VMg==", new DateTime(2024, 4, 14, 17, 44, 56, 514, DateTimeKind.Local).AddTicks(6598), "383af020-9cde-4113-98f2-b3259a3c31ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 4, 14, 17, 44, 56, 515, DateTimeKind.Local).AddTicks(9247), "b452990b-440d-4cb4-95a7-e4e68e60dc9c", "AQAAAAEAACcQAAAAEMQuX3hbDScUJg9pU7GRxgnQVKglBH3fOM+oPqS74lgkGbnaInizNFMoZ3wT5Z8Hvg==", new DateTime(2024, 4, 14, 17, 44, 56, 515, DateTimeKind.Local).AddTicks(9239), "163cdfd9-bbb2-4cff-82b6-3c9ee9e7d238" });
        }
    }
}
