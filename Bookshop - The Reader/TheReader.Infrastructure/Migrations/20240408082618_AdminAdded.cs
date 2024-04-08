using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RegistrationDate", "UserName" },
                values: new object[] { null, "2b54cc06-c4bf-425d-8fa8-aa194f8222e6", "Admin@gmail.com", "Adminov", "ADMIN@gmail.com", "ADMIN231", "AQAAAAEAACcQAAAAEJYiaMQfnpk3zlW76BUrKguslAdZ5tB1C/gfa24ebE2NhWgxdLVfIRRbU0oZ5cL9IA==", new DateTime(2024, 4, 8, 11, 26, 17, 874, DateTimeKind.Local).AddTicks(6247), "admin231" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RegistrationDate", "UserName" },
                values: new object[] { new DateTime(2024, 4, 8, 11, 26, 17, 875, DateTimeKind.Local).AddTicks(9757), "12955423-fcf1-4d3b-b677-3f3634cff3a2", "Guest", "Guestov", "GUEST231@gmail.com", "GUEST231", "AQAAAAEAACcQAAAAEMx/TG6Bfyl67is44hDLplpkhFAOAtn3FlSZbfsRP0EbXCXavMhsUmEhA+3KudLDUA==", new DateTime(2024, 4, 8, 11, 26, 17, 875, DateTimeKind.Local).AddTicks(9752), "Guest231" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RegistrationDate", "UserName" },
                values: new object[] { new DateTime(2024, 3, 20, 23, 56, 22, 542, DateTimeKind.Local).AddTicks(3850), "a33b60b0-2533-4fe7-ba6f-cea0588dd335", "admin231@gmail.com", "Admin", "admin231@gmail.com", null, "AQAAAAEAACcQAAAAEHVfbzEgSbCJSwR8m+qIAwh1/LbE6kWgLU0BEqEvzFzDcjcRVTOVz6ir40i6kKtZww==", new DateTime(2024, 3, 20, 23, 56, 22, 542, DateTimeKind.Local).AddTicks(3744), null });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RegistrationDate", "UserName" },
                values: new object[] { new DateTime(2024, 3, 20, 23, 56, 22, 543, DateTimeKind.Local).AddTicks(7917), "79bc049f-bfa4-4c21-8de4-840882da1821", "Guesr", "Guest", "guest231@gmail.com", null, "AQAAAAEAACcQAAAAENCGdxL3nWtbu8SG2otLAh1c3jRO9rZtsVN9nAM8K4MAtK32Bh56kx5sYKz20mIyvg==", new DateTime(2024, 3, 20, 23, 56, 22, 543, DateTimeKind.Local).AddTicks(7907), null });
        }
    }
}
