using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheReader.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "The first name of the current user"),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "The last name of the current user"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "The birth date of the current user"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The registration date of the current user"),
                    Gender = table.Column<int>(type: "int", nullable: false, comment: "The genre of the current user"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Is the user deleten"),
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current user identifier")
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<long>(type: "bigint", nullable: false, comment: "The International Standard Book Number"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "The current Book's Title"),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The current Book's Author"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The current Book's Description"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The current Book's Price"),
                    PublishedYear = table.Column<int>(type: "int", nullable: false, comment: "The published year of the current Book"),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
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
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Identifier the current user"),
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

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "17eb4845-eeb1-4fbe-9d2b-324e2ab92c93", 0, new DateTime(2024, 3, 13, 21, 58, 32, 390, DateTimeKind.Local).AddTicks(6564), "b444754e-1c29-45ec-baab-3ec109d82d1a", "admin231@gmail.com", false, "Admin", 0, false, "Admin", false, null, "admin231@gmail.com", null, "AQAAAAEAACcQAAAAEJwBWqf/4T3bzg4wHWGWm96+qCesdZdO6h2LzyDZpemNTBzN0biCeML/BrPChst+Ig==", null, false, new DateTime(2024, 3, 13, 21, 58, 32, 390, DateTimeKind.Local).AddTicks(6459), null, false, null },
                    { "641ca250-7c7a-40a5-8e3c-657714fb3d4a", 0, new DateTime(2024, 3, 13, 21, 58, 32, 392, DateTimeKind.Local).AddTicks(179), "f776cb8f-fc8d-4cb6-bba8-82f55dfe7151", "guest231@gmail.com", false, "Guesr", 1, false, "Guest", false, null, "guest231@gmail.com", null, "AQAAAAEAACcQAAAAEF+VDpf99noriFxmOgA/LmC3+xAj7qlB2vTPaMUP2uGsDJYsjtKZNQsQzCjyEVjlsg==", null, false, new DateTime(2024, 3, 13, 21, 58, 32, 392, DateTimeKind.Local).AddTicks(159), null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Фантазия" },
                    { 2, "Научна фантастика" },
                    { 3, "Класика" },
                    { 4, "Мистерия" },
                    { 5, "Ужаси" },
                    { 6, "Финанси" },
                    { 7, "Биография" },
                    { 8, "Храни и напитки" },
                    { 9, "История" },
                    { 10, "Пътуване" },
                    { 11, "Престъпление" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "GenreId", "ISBN", "ImageUrl", "Language", "OrderId", "Pages", "Price", "PublishedYear", "Title", "Weight" },
                values: new object[,]
                {
                    { 1, "Колектив", "Бил Кембъл изигра инструментална роля в растежа на няколко видни компании като Google, Apple и Intuit, насърчавайки дълбоки връзки с визионери от Силициевата долина, включително Стив Джобс, Лари Пейдж и Ерик Шмид. В допълнение, този бизнес гений е ментор на десетки други важни лидери на двата бряга, от предприемачи до рискови капиталисти до педагози до футболисти, оставяйки след смъртта си през 2016 г. наследство от разрастващи се компании, успешни хора, уважение, приятелство и любов.Лидерите в Google в продължение на повече от десетилетие, Ерик Шмид, Джонатан Розенберг и Алън Ийгъл изпитаха от първа ръка как човекът, известен като треньора Бил, изгради доверителни взаимоотношения, насърчи личностното израстване – дори при тези на върха на кариерата си – вдъхнови смелост и идентифицира и разреши тлеещото напрежение, което неизбежно възниква в бързо променящи се среди. За да почетат своя наставник и да вдъхновят и учат бъдещите поколения, те са кодирали неговата мъдрост в това основно ръководство.Въз основа на интервюта с над осемдесет души, които са познавали и обичали Бил Кембъл, Trillion Dollar Coach обяснява принципите на треньора и ги илюстрира с истории от много велики хора и компании, с които е работил. Резултатът е план за далновидни бизнес лидери и мениджъри, който ще им помогне да създадат по-ефективни и по-бързо развиващи се култури, екипи и компании.", 6, 9781473675988L, "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/t/r/2b7a8621ac2bd4eaa7e74423ad815c14/trillion-dollar-coach-30.jpg", "Български", null, 240, 26m, 2020, "Трилиони", 0.17000000000000001 },
                    { 2, "Ватсаяна Маланага", "За първи път на български в оригиналния си и най-пълен вариант излиза един от най-дискутираните и експлоатирани текстове на древността – древноиндийската библия на любовното изкуство “Камасутра” от Ватсаяна Маланага.Сутра е древен свещен текст, сборник от учения, препоръки и наставления, а Кама – наслаждаване с ръководените от разума сетива, съединени с тялото и съзнанието за удоволствието, породено от докосването на тялото. “След като създаде мъжа и жената, Праджапати (“владетелят на сътвореното”, бащата на боговете, творецът на света) създаде и учение от сто хиляди части, което да ги води в живота им.” В първоначалния си вид това учение се е състояло от три главни части – за дхарма (духовния живот), артхи (социалния живот) и кама (сетивния живот). По-късно сакралният текст за кама бил многократно преправян и съкращаван, докато се оформи достигналият до нас от ІІ в. сл. хр. окончателен вариант на Ватсаяна Маланага. В този вариант учението е оформено в 7 раздела – за общите въпроси, за прегръдките, за любовното сливане, за единствената съпруга, за чуждите жени, за куртизанките, за изкуството на прелъстяването, церовете за сила и пр.Всъщност, учението на Камасутра не предлага единствено система от техники, любовни пози или методи за извличане на максимална наслада, а също многобройни съвети за уменията, които любовниците трябва да проявят в акта на сливане:", 3, 9545283033L, "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/k/a/26310e438a5a1fb8622738f1e5d34f8b/kamasutra-31.jpg", "Български", null, 200, 15.60m, 2008, "Камасутра", 0.28000000000000003 },
                    { 4, "Ашли Ванс", "Единствената официална биография на Илън Мъск, написана с неговото специално съдействие.Илън Мъск - човекът зад PayPal, Tesla Motors, SpaceX, SolarCity, Hyperloop и идеята за глобална комуникационна мрежа. Гениалният визионер - Хенри Форд, Томас Едисън и Стив Джобс в едно. Най-дръзкият предприемач на Силициевата долина: инженер, изобретател и индустриалец. Прагматикът и фантастът, който подготвя човечеството за колонизация на Марс.Мъск стои начело на един от най-големите подеми в историята на бизнеса. Той е единственият предприемач с достатъчно енергия, сила и въображение, който инвестира цялото си богатство в иновации от друго измерение и революционизира три индустрии едновременно - космическата, автомобилната и енергийната. Мисията на живота му изглежда фантастична, но ако Мъск успее да си купи достатъчно време, той ще предприеме най-голямото пътуване за спасение на човечеството.Написана след повече от 50 часа разговори с Мъск и интервюта с около 300 души, книгата проследява пътя от нелекото детство на Илън Мъск в ЮАР до върховете на световния бизнес. Авторът Ашли Ванс разказва историите на компаниите на Мъск, които променят света, и живота на човека, който, независимо дали е обичан, или мразен, възхваляван или отричан, създава едно невероятно бъдеще.Бестселър на Ню Йорк Таймс и една от най-добрите книги на 2015 г. според Уолстрийт Джърнал и Амазон.Иска ми се да умра с мисълта, че пред човечеството има светло бъдеще. Ако можем да си осигурим чиста енергия и да станем междупланетарна раса с устойчива цивилизация на друга планета - за да се справим с най-лошия сценарий, в който човешкото съзнание е заличено - тогава... мисля, че ще бъде много хубаво.Илън Мъск Ашли Ванс е журналист, завършил колежа Pomona. Повече от 10 години пише за технологичната индустрия в Сан Франциско и е известен историк на Силициевата долина. Работил е за New York Times и The Register, а понастоящем - за списание Bloomberg Businessweek. Водещ е на телевизионно предаване.", 7, 9789547713611L, "https://www.book.store.bg/lrgimg/180958/ilyn-mysk-biografia.jpg", "Български", null, 416, 25m, 2016, "Илън Мъск", 0.59599999999999997 },
                    { 5, "Робърт Кийосаки", "Уроците за парите, на които богатите учат децата си, а бедните и средната класа - не. Робърт Кийосаки промени начина, по който милиони хора по света мислят за парите. Той притежава репутация на човек, чиито възгледи често противоречат на конвенционалното мислене със своята смелост и безкомпромисна откровеност. Той е световно признат експерт по финансова грамотност.", 6, 9789542929550L, "https://cdn.ozone.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/o/08f6ab8aa9194c941520c56f863d199c/bogat-tatko--beden-tatko-30.jpg", "Български", null, 360, 15.95m, 2018, "Богат татко, беден татко", 0.39000000000000001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BooksCarts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "UsersProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
