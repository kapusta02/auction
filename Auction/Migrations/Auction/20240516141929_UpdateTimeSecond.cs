using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auction.Migrations.Auction
{
    /// <inheritdoc />
    public partial class UpdateTimeSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("1c815e59-f915-4d70-980f-7f4ed8d9b8fb"), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new TimeSpan(2, 0, 0, 0, 0), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("60ddc68a-c9b6-4f03-9e03-e4d2330908d9") },
                    { new Guid("4fd933ee-031c-4c78-a290-6304f31334cf"), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new TimeSpan(2, 0, 0, 0, 0), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8b1cf396-20dc-4137-bfce-f8dfef451e66") }
                });

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "Id", "Balance", "Currency", "UserId" },
                values: new object[,]
                {
                    { new Guid("7e344ca9-f0d0-4144-afc4-bab271d7a8c1"), 1023100.0m, "Kaspi Coin", new Guid("5fe86c91-eaca-40e2-bcf1-3ed7868b82bc") },
                    { new Guid("b7586b69-1122-42e9-80fb-75bd44a1cd49"), 1000000.0m, "Kaspi Coin", new Guid("deb87b47-3c96-4f87-a14a-dbbc018f4dcf") },
                    { new Guid("d0d1e513-daba-484b-936d-a88a27e7909b"), 1004300.0m, "Kaspi Coin", new Guid("96f5c4b7-40df-4530-8cee-182d54c9d29f") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lot",
                keyColumn: "Id",
                keyValue: new Guid("1c815e59-f915-4d70-980f-7f4ed8d9b8fb"));

            migrationBuilder.DeleteData(
                table: "Lot",
                keyColumn: "Id",
                keyValue: new Guid("4fd933ee-031c-4c78-a290-6304f31334cf"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("7e344ca9-f0d0-4144-afc4-bab271d7a8c1"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("b7586b69-1122-42e9-80fb-75bd44a1cd49"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("d0d1e513-daba-484b-936d-a88a27e7909b"));

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
    }
}
