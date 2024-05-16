using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auction.Migrations.Auction
{
    /// <inheritdoc />
    public partial class UpdateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("64176c8c-2df6-4e34-b00f-1b0e5544c3a7"), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new DateTime(2020, 2, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9c6e273e-a1fc-47cb-a38b-c8b32b6cebbd") },
                    { new Guid("7a2bb6f5-6d5e-4475-a341-bc43ec41157e"), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new DateTime(2020, 2, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("746975f7-6e50-4821-84f3-27d863486dbc") }
                });

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "Id", "Balance", "Currency", "UserId" },
                values: new object[,]
                {
                    { new Guid("2588ede3-b1b1-4115-b2fa-7a9000112d2e"), 1023100.0m, "Kaspi Coin", new Guid("fe0da4e0-119c-4cdd-905b-637caa70b924") },
                    { new Guid("3578a870-9a13-4cf6-b988-8f968d8ca898"), 1000000.0m, "Kaspi Coin", new Guid("bf121afa-652e-483e-a663-77493a807ce3") },
                    { new Guid("fbca4c62-255e-4beb-99f6-213fb2fadd96"), 1004300.0m, "Kaspi Coin", new Guid("26653fc6-bae5-47a4-b30b-40d912f655b1") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lot",
                keyColumn: "Id",
                keyValue: new Guid("64176c8c-2df6-4e34-b00f-1b0e5544c3a7"));

            migrationBuilder.DeleteData(
                table: "Lot",
                keyColumn: "Id",
                keyValue: new Guid("7a2bb6f5-6d5e-4475-a341-bc43ec41157e"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("2588ede3-b1b1-4115-b2fa-7a9000112d2e"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("3578a870-9a13-4cf6-b988-8f968d8ca898"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("fbca4c62-255e-4beb-99f6-213fb2fadd96"));

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
    }
}
