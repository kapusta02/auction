using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auction.Migrations.Auction
{
    /// <inheritdoc />
    public partial class UpdateLotTimeSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lot",
                keyColumn: "Id",
                keyValue: new Guid("18cbd317-b831-467c-b90b-f950fb9453fe"));

            migrationBuilder.DeleteData(
                table: "Lot",
                keyColumn: "Id",
                keyValue: new Guid("75d6586a-21cc-452f-b60f-e4cd4272ad96"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("34c87c8c-73d6-430a-907b-6286fbc0ebcd"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("5432d021-ef7b-4df7-9a9b-bcde0f588ec7"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("b672a33c-1f46-4f60-aac9-2a6f353ed9a6"));

            migrationBuilder.InsertData(
                table: "Lot",
                columns: new[] { "Id", "Description", "Images", "Name", "StartPrice", "Tags", "TradingDuration", "TradingStart", "UserId" },
                values: new object[,]
                {
                    { new Guid("61761a18-4ac3-4dec-9f0a-b4e57007f656"), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new TimeSpan(2, 0, 0, 0, 0), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f27139b5-8891-4cba-bdb5-f63ac579e4de") },
                    { new Guid("e5c7e1c5-c9a2-47c9-9d7e-eb3fa4ab3f51"), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new TimeSpan(2, 0, 0, 0, 0), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3c7868a0-7d65-4314-8470-a67f101ffc1a") }
                });

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "Id", "Balance", "Currency", "UserId" },
                values: new object[,]
                {
                    { new Guid("036204bb-6db5-4d77-946a-3669ecbe58dc"), 1000000.0m, "Kaspi Coin", new Guid("06ee30b1-4afc-4158-a8be-76f851f2af51") },
                    { new Guid("0d1f8015-f640-4031-a578-4fac466ed932"), 1004300.0m, "Kaspi Coin", new Guid("5f0297fa-7cd6-4363-9fa0-df45fcbdadca") },
                    { new Guid("6c853bd0-663c-4dfd-bdc3-0d94c8e103e2"), 1023100.0m, "Kaspi Coin", new Guid("cb7ce95e-2ba3-43cd-926e-8c7b8434a62d") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lot",
                keyColumn: "Id",
                keyValue: new Guid("61761a18-4ac3-4dec-9f0a-b4e57007f656"));

            migrationBuilder.DeleteData(
                table: "Lot",
                keyColumn: "Id",
                keyValue: new Guid("e5c7e1c5-c9a2-47c9-9d7e-eb3fa4ab3f51"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("036204bb-6db5-4d77-946a-3669ecbe58dc"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("0d1f8015-f640-4031-a578-4fac466ed932"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("6c853bd0-663c-4dfd-bdc3-0d94c8e103e2"));

            migrationBuilder.InsertData(
                table: "Lot",
                columns: new[] { "Id", "Description", "Images", "Name", "StartPrice", "Tags", "TradingDuration", "TradingStart", "UserId" },
                values: new object[,]
                {
                    { new Guid("18cbd317-b831-467c-b90b-f950fb9453fe"), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new TimeSpan(2, 0, 0, 0, 0), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("38b0d50c-6e1d-41e8-af5d-cc2cea8708ae") },
                    { new Guid("75d6586a-21cc-452f-b60f-e4cd4272ad96"), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new TimeSpan(2), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("48959c77-c314-43cf-8d72-aa3c6aff2ab3") }
                });

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "Id", "Balance", "Currency", "UserId" },
                values: new object[,]
                {
                    { new Guid("34c87c8c-73d6-430a-907b-6286fbc0ebcd"), 1000000.0m, "Kaspi Coin", new Guid("466a0766-7b8c-4bdc-b6c4-f99410eadd26") },
                    { new Guid("5432d021-ef7b-4df7-9a9b-bcde0f588ec7"), 1023100.0m, "Kaspi Coin", new Guid("9b11d45c-752d-45e4-9df5-9b8190777ca5") },
                    { new Guid("b672a33c-1f46-4f60-aac9-2a6f353ed9a6"), 1004300.0m, "Kaspi Coin", new Guid("ee22f658-e25e-4265-9afb-09132f2178f9") }
                });
        }
    }
}
