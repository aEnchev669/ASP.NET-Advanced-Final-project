﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class Username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "46680643-adfc-4e57-87de-e0655c8fdc32", "AQAAAAEAACcQAAAAEBasXHBwJhUTl5VHLZzK0LnFeial0G7sF0fH2XAlbkmsYF6qs7gmg3FxYXqOZUPc2g==", new DateTime(2024, 4, 20, 8, 22, 14, 504, DateTimeKind.Local).AddTicks(5326), "1ad806f9-72da-456c-94fb-cd75a30e31f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 4, 20, 8, 22, 14, 505, DateTimeKind.Local).AddTicks(8953), "549cece1-68e4-4adb-8194-ada35c41f553", "AQAAAAEAACcQAAAAEJDguLFSZtvJg6g+Lhn8hMe6IgBoQvV3xLBzJ6PDGSQ/9kt9HTLvUWMob7R4lduGZw==", new DateTime(2024, 4, 20, 8, 22, 14, 505, DateTimeKind.Local).AddTicks(8945), "8b504d36-0ffc-400d-bcc5-099c782bf47f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
