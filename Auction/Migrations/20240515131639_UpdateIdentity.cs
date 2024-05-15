using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auction.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Biddings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    LotId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Bid = table.Column<double>(type: "double", nullable: false),
                    FinalPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biddings", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Images = table.Column<string>(type: "longtext", nullable: false),
                    StartPrice = table.Column<double>(type: "double", nullable: false),
                    Tags = table.Column<string>(type: "longtext", nullable: false),
                    TradingStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TradingDuration = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsBlocked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "longtext", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Balance = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Biddings",
                columns: new[] { "Id", "Bid", "FinalPrice", "LotId", "UserId" },
                values: new object[,]
                {
                    { new Guid("192b8331-a7d4-4128-97d1-0fe6e3f2fc16"), 0.0, 1020.0, new Guid("7c7e1068-076e-4e83-ac84-f77623dd0d0a"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("23b34e24-c0dc-4885-8aa9-278f3f6ba6e2"), 0.0, 1000.0, new Guid("92ac8d50-a4f5-49d0-a70e-908043919472"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "Description", "Images", "Name", "StartPrice", "Tags", "TradingDuration", "TradingStart", "UserId" },
                values: new object[,]
                {
                    { new Guid("12c434c3-f0fa-485b-833f-811fba946456"), "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.10000000000002, "Test", "2 days", new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("db3cbf94-7dbc-4e08-b3be-91c9d3b7a961") },
                    { new Guid("3fdf1085-2e6c-40d8-8c13-718cda485bde"), "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.10000000000002, "Test", "2 days", new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cad09093-da48-4282-b4b8-9d9711b5a14e") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1bc2046d-6992-4a19-a642-16c49ccd28e9"), 0, "1c24c46b-bf87-4bbe-9a92-01831b14da6d", null, false, false, false, null, null, null, "$2a$11$k11P4pbuCkAtqoySzkv8Le7xScvE4HGTt21EKqCLEyMWD2tWsB8ru", null, false, 0, null, false, "Tom" },
                    { new Guid("2af5f100-19a0-4679-99c6-78fc17362ab2"), 0, "fca20db0-103e-4dbb-b3b6-6a7c08147b17", null, false, false, false, null, null, null, "$2a$11$gW8qklPMoGcZriPWgrW/teA/yB7y6eUe84HSNgPrpxWAr5ZdbWBEu", null, false, 1, null, false, "Jerry" },
                    { new Guid("309e00a7-4c0f-4bcd-82db-dfbc83461a14"), 0, "a8ea105a-e7e6-4fff-9f6a-3576887108f0", null, false, false, false, null, null, null, "$2a$11$sIdIAwtpdq9M4MuMuM8/3eS04jwl0vypGvMG.L2oWhcUnYczSH5IO", null, false, 2, null, false, "Bob" }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "UserId" },
                values: new object[,]
                {
                    { new Guid("4c7ea6df-fee7-47f0-a21a-860123c8e282"), 1004300.0, new Guid("ee66d7a0-47f3-454c-b1a6-cdc2dfc73f36") },
                    { new Guid("56a051af-1bc3-48fd-9bc5-75f884e6cbea"), 1023100.0, new Guid("4239751e-e234-4f7e-b734-4fd77f285beb") },
                    { new Guid("785f8f78-44cf-4a1c-b463-19cf3333eb83"), 1000000.0, new Guid("81f10772-d815-4c8c-b881-316f6ea83d81") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biddings");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Wallets");
        }
    }
}
