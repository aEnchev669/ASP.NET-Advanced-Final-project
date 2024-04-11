using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class IsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "e840bb51-1329-4a27-a4f4-0a3fc6fdfd09", "AQAAAAEAACcQAAAAEO4AHONxG39vAPko3s+18BfwryPmcTBunbvhbKI5+TNuJOePwTDKXCT4U6fMlpPmWg==", new DateTime(2024, 4, 8, 21, 10, 25, 680, DateTimeKind.Local).AddTicks(8790), "b946b479-5fe9-4842-bc83-2dbae5af87af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 4, 8, 21, 10, 25, 682, DateTimeKind.Local).AddTicks(1583), "6ff61436-a19c-4817-8033-86d9b88b7d86", "AQAAAAEAACcQAAAAEODdaTckqp38/B9fzkUT3CgxOckYFd36hLB6XdB9h7a0Fa2VaNBM3mSL7r7YBf8ZvA==", new DateTime(2024, 4, 8, 21, 10, 25, 682, DateTimeKind.Local).AddTicks(1575), "fa2ae720-be0d-4797-bbf0-f3f92bb3e5b7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "bb713dc1-2eeb-4a48-8382-387778308ba7", "AQAAAAEAACcQAAAAEAyhr8S/YvSYS1HSjpQxPJa/YCOypzxf06vgat/vV/Hmqm3MpE0V5Uuqts+TU0UFBA==", new DateTime(2024, 4, 8, 17, 1, 36, 275, DateTimeKind.Local).AddTicks(6058), "16de10a4-ea9e-4e4f-88ef-abc275d1ef23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 4, 8, 17, 1, 36, 276, DateTimeKind.Local).AddTicks(9889), "8aa05387-ef79-4b52-9248-cca1a3fd6f12", "AQAAAAEAACcQAAAAEDAmbF5QsLZCHI67skf7jhw55uvsq5dpyJUhgSFXAqODpy6eouEIDVmpD2Nv46UtXA==", new DateTime(2024, 4, 8, 17, 1, 36, 276, DateTimeKind.Local).AddTicks(9870), "b4bc2c5e-4da5-4cf3-bf94-5949f9287cbc" });
        }
    }
}
