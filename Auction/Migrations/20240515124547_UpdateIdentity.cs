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
                    { new Guid("04dcc24a-6f71-4f8c-bdb1-d5b8eb42548f"), 0.0, 1020.0, new Guid("f1595851-7944-43bf-8f9a-fdf952091566"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("275116f2-a053-4e57-bb03-4dca5498fc1e"), 0.0, 1000.0, new Guid("ce68d480-b9b0-472b-891a-0d54bed32406"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "Description", "Images", "Name", "StartPrice", "Tags", "TradingDuration", "TradingStart", "UserId" },
                values: new object[,]
                {
                    { new Guid("6be00f42-5a04-4283-8a98-881710ac7667"), "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.10000000000002, "Test", "2 days", new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7147d021-e603-4bd1-8706-9864ce124f00") },
                    { new Guid("f6b88209-eafe-489b-8d1d-82930605bfab"), "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.10000000000002, "Test", "2 days", new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4fce8e49-6b11-43c4-9a30-0a89f4a97ce7") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("152e4050-7d88-45cb-9b90-122750c0366e"), 0, "177acc12-7a38-4b11-bc9e-b52be5c3dde4", null, false, false, null, null, null, "$2a$11$3yT/5zmK6XxjKPsshjwLZOUbKhrIJvr2jr24.oNb.T449s4ZDKyh2", null, false, null, false, "Tom" },
                    { new Guid("74160c9b-b36d-4d3a-adc3-fd6751faf06c"), 0, "349fbb1c-887f-456f-9414-d49f1ed4d513", null, false, false, null, null, null, "$2a$11$rOWaFBDx/Yrn9f6yUVszgOyfR6s/w3ghhlep7Mv/WPXW8/gYGFDta", null, false, null, false, "Bob" },
                    { new Guid("d1c5077f-7810-461f-a0a5-bf202299e060"), 0, "5d8f98dd-cd3d-4edb-b9bb-ea3f077f7336", null, false, false, null, null, null, "$2a$11$70R.Hq0OPSkJfmqOXtNmieC03GvTwj0x8pKylEtN04PjjlaeFfVNm", null, false, null, false, "Jerry" }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "UserId" },
                values: new object[,]
                {
                    { new Guid("339c5a45-8fee-4d26-8f8d-d0bd0cf5b120"), 1000000.0, new Guid("d3041f3d-180f-45c1-a8dc-39e700debddb") },
                    { new Guid("34baed56-65b9-4e6c-aabc-4a5d58f9706c"), 1023100.0, new Guid("fc1e7b24-6cf2-4f1c-a23b-d00c32b7263f") },
                    { new Guid("a1685adf-a065-41dd-a5fd-e23db3f74fa8"), 1004300.0, new Guid("f5166248-8423-4a57-8599-025d71490f2d") }
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
