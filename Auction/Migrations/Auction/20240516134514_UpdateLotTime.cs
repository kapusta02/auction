using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auction.Migrations.Auction
{
    /// <inheritdoc />
    public partial class UpdateLotTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lot",
                keyColumn: "Id",
                keyValue: new Guid("0cc8a5c4-cb6d-4e94-9723-7ca823398556"));

            migrationBuilder.DeleteData(
                table: "Lot",
                keyColumn: "Id",
                keyValue: new Guid("af0944fd-a1d0-46c6-b8f1-102ffc0e791a"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("7f0dc6dc-b4d4-4faf-a263-c6af40c1a99f"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("86540527-c426-41f0-b416-84588edc27e8"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("d5d8efc4-6b87-4cf8-b726-f0412b97509d"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("0cc8a5c4-cb6d-4e94-9723-7ca823398556"), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new TimeSpan(2), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("16f01db6-72d8-47f2-b4fe-0b62f3c0324a") },
                    { new Guid("af0944fd-a1d0-46c6-b8f1-102ffc0e791a"), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new TimeSpan(2), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a3c757d-d096-4111-a4c4-c31fa0c0b6ef") }
                });

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "Id", "Balance", "Currency", "UserId" },
                values: new object[,]
                {
                    { new Guid("7f0dc6dc-b4d4-4faf-a263-c6af40c1a99f"), 1004300.0m, "Kaspi Coin", new Guid("157b95ba-4b97-473d-881c-f53470965981") },
                    { new Guid("86540527-c426-41f0-b416-84588edc27e8"), 1000000.0m, "Kaspi Coin", new Guid("28a24d6f-9c47-4a5b-820a-d15beb9a634e") },
                    { new Guid("d5d8efc4-6b87-4cf8-b726-f0412b97509d"), 1023100.0m, "Kaspi Coin", new Guid("e234697b-190a-480b-8674-a4614773a87b") }
                });
        }
    }
}
