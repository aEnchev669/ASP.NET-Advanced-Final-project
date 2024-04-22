using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class EventDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsCarts_Event_EventId",
                table: "EventsCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsParticipants_Event_EventId",
                table: "EventsParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "841c97a5-6e18-4c31-bced-41f2e1f686cf", "AQAAAAEAACcQAAAAEPbGaFxTzvZcu3hLG8kJB5jkE5P6vXikXCI9AwKtXpdNLJrHSGjAgaqxsVqnICElNw==", new DateTime(2024, 4, 21, 14, 35, 23, 320, DateTimeKind.Local).AddTicks(2490), "555657ea-2af0-4c79-a3af-5e13eefc3fe6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "7590a29d-45e8-494f-a196-4ea4b9076aff", "AQAAAAEAACcQAAAAEGsYpJ/cLAQb+OHxnhCWHd7IR7ovub8Rh69c6z6ElogJK+F+FHVsyWHVb5IumTsZRA==", new DateTime(2024, 4, 21, 14, 35, 23, 321, DateTimeKind.Local).AddTicks(5756), "66dcac0e-f4d4-48cf-a98b-ad773159f8bd" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventsCarts_Events_EventId",
                table: "EventsCarts",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsParticipants_Events_EventId",
                table: "EventsParticipants",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsCarts_Events_EventId",
                table: "EventsCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsParticipants_Events_EventId",
                table: "EventsParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "a439f21e-b58a-41e7-9294-ec868774a86a", "AQAAAAEAACcQAAAAEOMNpmtEG6/ooey729zGZHttbBFJcIkOz6a3ejbfa7gAMNRvkl+hCC04NHeCpmhJKQ==", new DateTime(2024, 4, 21, 13, 13, 13, 658, DateTimeKind.Local).AddTicks(7506), "6e888735-57b4-4adc-9479-4fb947f29f81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641ca250-7c7a-40a5-8e3c-657714fb3d4a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "f9c4f1a3-1e23-4df5-a38d-2b071f6f412a", "AQAAAAEAACcQAAAAEELJGL4lLIn4ykv4D4WloYDaq5KVg2Tyr4joa7EH9RT0KLaW4sSdv7nbIjCejofP9g==", new DateTime(2024, 4, 21, 13, 13, 13, 660, DateTimeKind.Local).AddTicks(1566), "65410aa2-bef8-445c-ae0f-5b99d12200e3" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventsCarts_Event_EventId",
                table: "EventsCarts",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsParticipants_Event_EventId",
                table: "EventsParticipants",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
