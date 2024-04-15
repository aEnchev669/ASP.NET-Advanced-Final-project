using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class BookCartQuanittyAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BooksCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "73fed804-5c1c-4d2b-8fd2-adf40b8502e7", "AQAAAAEAACcQAAAAEL+te4n7+igSyr/xdWoSLBzBhJkkSoOymzDgjX4w2PP24ip/Sr4+XJhrWWm020wiyQ==", new DateTime(2024, 4, 14, 17, 7, 26, 734, DateTimeKind.Local).AddTicks(26), "29b6201b-1920-4ed2-b413-cbbdca649eda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 4, 14, 17, 7, 26, 735, DateTimeKind.Local).AddTicks(3170), "89713858-732d-475b-9a66-88899a3dd6c0", "AQAAAAEAACcQAAAAEFhhucGFLbdNrN/oU6TwAHDQzzLy7dXZhZeMRAq331LG7UHABvOga1nz54Qy3MnbAQ==", new DateTime(2024, 4, 14, 17, 7, 26, 735, DateTimeKind.Local).AddTicks(3162), "58263952-891a-403e-a1be-fb32090d715e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BooksCarts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "b73fc818-536d-4e97-ac87-272c0d54101b", "AQAAAAEAACcQAAAAEItz2Afa4b7762erRAf8ZcjF+f+BF3e2QrmIsZ5pFG6x5yEZG30rLV+wZux+VKcM3w==", new DateTime(2024, 4, 9, 21, 37, 58, 422, DateTimeKind.Local).AddTicks(6652), "b89dc96c-4081-4ea8-8e42-1b67b0959d40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 4, 9, 21, 37, 58, 424, DateTimeKind.Local).AddTicks(636), "6ce0fa74-039d-423c-adbd-973d5a572e41", "AQAAAAEAACcQAAAAEL7tNJzffcTwe58DP0+pekhDgiJ4wZw2K/wZwOLYh3V38i72SAURLlOp5atOOiW01Q==", new DateTime(2024, 4, 9, 21, 37, 58, 424, DateTimeKind.Local).AddTicks(628), "499fd89c-2883-42c7-8c79-d0768f750caa" });
        }
    }
}
