using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class CartChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Orders_OrderId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_OrderId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carts_CartId",
                table: "Orders",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carts_CartId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Email of the creator of the current order");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Street of the creator of the current order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Books",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Books_OrderId",
                table: "Books",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Orders_OrderId",
                table: "Books",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
