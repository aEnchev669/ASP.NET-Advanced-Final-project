using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class BookCartNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "1af68f5c-a555-4768-b204-e1f8e895fc85", "AQAAAAEAACcQAAAAEN0ke4C3AGEyq9p2bjhQ+PgSVdvaGx1DuxDvl7xHQuOEqUllWvNSbUGQt1DhP9mdnQ==", new DateTime(2024, 4, 14, 17, 13, 24, 942, DateTimeKind.Local).AddTicks(6331), "0a158c1c-b89f-4aba-8d64-2f53dc1b14a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 4, 14, 17, 13, 24, 944, DateTimeKind.Local).AddTicks(99), "fc98f225-3fc2-4985-8509-2c237a0c8d7a", "AQAAAAEAACcQAAAAEM71DONACh7P0DLRewaIP1eheKFrTdHGvbhDAHLzslfuuFXwFtj10KO0CNJtJrmlSQ==", new DateTime(2024, 4, 14, 17, 13, 24, 944, DateTimeKind.Local).AddTicks(79), "9d5c8d00-6328-417c-b96b-5f5620c30d2a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
