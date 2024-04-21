using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class SetRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "d73c95a2-a87f-43e6-b367-74a40e5b8ddd", "AQAAAAEAACcQAAAAEBz3/AYgcQT4D5Y8B/yT9i8zchyGojzjvIyAQ7MLSjPcXTKQrzi3ZCA3xR7YTs2FIw==", new DateTime(2024, 4, 20, 8, 5, 52, 476, DateTimeKind.Local).AddTicks(1571), "81d5eb9f-1bfd-4442-a3fd-f910313df576" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 4, 20, 8, 5, 52, 477, DateTimeKind.Local).AddTicks(4397), "b5386713-deb6-4ce2-bdb1-1b29e6cddb69", "AQAAAAEAACcQAAAAECysSKbxgTAmMBsBaIBaAid2DDx6Ny+Ki7p+tLcHK2zCrgGyPJuARBSET07Yw7UhSQ==", new DateTime(2024, 4, 20, 8, 5, 52, 477, DateTimeKind.Local).AddTicks(4388), "be703337-5c60-419b-b398-d5bd30f121b8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
