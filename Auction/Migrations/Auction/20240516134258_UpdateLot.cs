using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auction.Migrations.Auction
{
    /// <inheritdoc />
    public partial class UpdateLot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("8355754f-f38f-4873-a247-8155b74a51a0"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("a19a5d66-42e8-4e47-8201-96337152f06c"));

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: new Guid("a88c32a7-72a7-4aeb-885a-97168d4630a9"));

            migrationBuilder.CreateTable(
                name: "Lot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Images = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    StartPrice = table.Column<decimal>(type: "TEXT", maxLength: 4, nullable: false),
                    Tags = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    TradingStart = table.Column<DateTime>(type: "TEXT", maxLength: 20, nullable: false),
                    TradingDuration = table.Column<TimeSpan>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Lot_Id",
                table: "Lot",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lot");

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
                table: "Wallet",
                columns: new[] { "Id", "Balance", "Currency", "UserId" },
                values: new object[,]
                {
                    { new Guid("8355754f-f38f-4873-a247-8155b74a51a0"), 1000000.0m, "Kaspi Coin", new Guid("5c434df2-8a95-48df-9d5c-81f5adffcef8") },
                    { new Guid("a19a5d66-42e8-4e47-8201-96337152f06c"), 1004300.0m, "Kaspi Coin", new Guid("65b5e8da-8a81-42e8-b307-5596a2f53df5") },
                    { new Guid("a88c32a7-72a7-4aeb-885a-97168d4630a9"), 1023100.0m, "Kaspi Coin", new Guid("6bfb27fc-492a-41b5-8e84-a76447ab6b36") }
                });
        }
    }
}
