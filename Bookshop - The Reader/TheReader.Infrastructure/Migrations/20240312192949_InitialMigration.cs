using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "The first name of the current user"),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "The last name of the current user"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "The birth date of the current user"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The registration date of the current user"),
                    Gender = table.Column<int>(type: "int", nullable: false, comment: "The genre of the current user"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                },
                comment: "Current user");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Genre's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The current Genre's Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                },
                comment: "Current genre");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Current cart identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "The current user identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Current cart");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Current Order Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "First ame of the creator of the current order"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Last name of the creator of the current order"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Email of the creator of the current order"),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Phone number of the creator of the current order"),
                    City = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "City of the creator of the current order"),
                    PostalCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false, comment: "PostalCode of the creator of the current order"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Street of the creator of the current order"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Creation date of the current order"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The total of the current order"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<int>(type: "int", nullable: false, comment: "The International Standard Book Number"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "The current Book's Title"),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The current Book's Author"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The current Book's Description"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The current Book's Price"),
                    StockQuantity = table.Column<int>(type: "int", nullable: false, comment: "The stock Quantity of the current Book"),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The published date of the current Book"),
                    GenreId = table.Column<int>(type: "int", nullable: false, comment: "Genre Identifier"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "The current Book's cover image url"),
                    Language = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "The current Book language"),
                    Weight = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: false, comment: "The currrent Book weight"),
                    Pages = table.Column<int>(type: "int", nullable: false, comment: "The current Book's pages count"),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                },
                comment: "Current Book");

            migrationBuilder.CreateTable(
                name: "BooksCarts",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The Current book's ientifier"),
                    CartId = table.Column<int>(type: "int", nullable: false, comment: "The current cart idetifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksCarts", x => new { x.BookId, x.CartId });
                    table.ForeignKey(
                        name: "FK_BooksCarts_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The cart with books");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Current comment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Current comment text"),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date of creation of the current comemnt"),
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "Book identifier"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Current Comment");

            migrationBuilder.CreateTable(
                name: "UsersProducts",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false, comment: "Identifier the current user"),
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "Book id of the current user"),
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Current Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProducts", x => new { x.ApplicationUserId, x.BookId });
                    table.ForeignKey(
                        name: "FK_UsersProducts_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersProducts_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User's products");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_OrderId",
                table: "Books",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksCarts_CartId",
                table: "BooksCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProducts_BookId",
                table: "UsersProducts",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksCarts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "UsersProducts");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}
