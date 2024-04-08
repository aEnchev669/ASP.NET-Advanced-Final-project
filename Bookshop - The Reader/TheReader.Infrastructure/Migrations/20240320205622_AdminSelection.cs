using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class AdminSelection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate" },
                values: new object[] { new DateTime(2024, 3, 20, 23, 56, 22, 542, DateTimeKind.Local).AddTicks(3850), "a33b60b0-2533-4fe7-ba6f-cea0588dd335", "AQAAAAEAACcQAAAAEHVfbzEgSbCJSwR8m+qIAwh1/LbE6kWgLU0BEqEvzFzDcjcRVTOVz6ir40i6kKtZww==", new DateTime(2024, 3, 20, 23, 56, 22, 542, DateTimeKind.Local).AddTicks(3744) });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate" },
                values: new object[] { new DateTime(2024, 3, 20, 23, 56, 22, 543, DateTimeKind.Local).AddTicks(7917), "79bc049f-bfa4-4c21-8de4-840882da1821", "AQAAAAEAACcQAAAAENCGdxL3nWtbu8SG2otLAh1c3jRO9rZtsVN9nAM8K4MAtK32Bh56kx5sYKz20mIyvg==", new DateTime(2024, 3, 20, 23, 56, 22, 543, DateTimeKind.Local).AddTicks(7907) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate" },
                values: new object[] { new DateTime(2024, 3, 13, 21, 58, 32, 390, DateTimeKind.Local).AddTicks(6564), "b444754e-1c29-45ec-baab-3ec109d82d1a", "AQAAAAEAACcQAAAAEJwBWqf/4T3bzg4wHWGWm96+qCesdZdO6h2LzyDZpemNTBzN0biCeML/BrPChst+Ig==", new DateTime(2024, 3, 13, 21, 58, 32, 390, DateTimeKind.Local).AddTicks(6459) });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate" },
                values: new object[] { new DateTime(2024, 3, 13, 21, 58, 32, 392, DateTimeKind.Local).AddTicks(179), "f776cb8f-fc8d-4cb6-bba8-82f55dfe7151", "AQAAAAEAACcQAAAAEF+VDpf99noriFxmOgA/LmC3+xAj7qlB2vTPaMUP2uGsDJYsjtKZNQsQzCjyEVjlsg==", new DateTime(2024, 3, 13, 21, 58, 32, 392, DateTimeKind.Local).AddTicks(159) });
        }
    }
}
