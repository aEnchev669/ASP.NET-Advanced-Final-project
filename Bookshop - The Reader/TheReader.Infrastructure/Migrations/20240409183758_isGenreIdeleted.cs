using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class isGenreIdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Genres",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Genres");

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
    }
}
