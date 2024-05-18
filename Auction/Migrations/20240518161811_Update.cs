using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "490ba9de-b38e-4f13-b811-4558f2e348b9");

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: new Guid("b7ddd2d0-dfa4-46e3-a475-6e8b62cf3a87"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("71e112f9-442a-4626-bc5b-09d71895e30b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "039df29d-e213-454f-8888-edecff4c498c");

            migrationBuilder.DeleteData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: new Guid("528988a4-9a1f-48ba-b03f-640ba249a996"));

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBid",
                table: "Lots",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb499953-e9ff-45bf-bae7-9e33017893a1", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsBlocked", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb3ca938-28e9-4a7f-a1a4-c4c8528a746f", 0, "8f49e0cd-50ec-4a0e-b3fd-4e444e20633c", "peter@example.com", true, "Peter", false, "Parker", false, null, "PETER@EXAMPLE.COM", "PETER", "AQAAAAIAAYagAAAAEO+ZbmZFJ+UiI3OR2xv0zRz6Hk1DxkQeZ9WYzTPYADwEfZ2nsRxQqyQb72rrGdbXjg==", "+77771234567", true, "7b97acba-6bd1-4bcf-a319-e568f4890c9e", false, "peter" });

            migrationBuilder.InsertData(
                table: "Biddings",
                columns: new[] { "Id", "Bids", "CreatedAt", "FinalPrice", "IsBindingsStarted", "UpdatedAt" },
                values: new object[] { new Guid("b2212d51-a8db-4382-b99a-4919d9f377ee"), 0.0m, new DateTime(2024, 5, 18, 21, 18, 11, 84, DateTimeKind.Local).AddTicks(3738), 1000.0m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "BiddingId", "CreatedAt", "CurrentBid", "Description", "Images", "IsArchived", "IsStarted", "Name", "StartPrice", "Tags", "TradingDuration", "TradingStart", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("06703e74-5bd4-4efe-90e3-e3374560f8ba"), new Guid("b2212d51-a8db-4382-b99a-4919d9f377ee"), new DateTime(2024, 5, 18, 21, 18, 11, 84, DateTimeKind.Local).AddTicks(3759), 0.0m, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", false, false, "Lot #1", 937.1m, "Test", new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bb3ca938-28e9-4a7f-a1a4-c4c8528a746f" });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "CreatedAt", "Currency", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("eba061ee-cb3c-4cf3-ba33-3d2abeb94728"), 1000000.0m, new DateTime(2024, 5, 18, 21, 18, 11, 84, DateTimeKind.Local).AddTicks(3696), "Kaspi Coin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bb3ca938-28e9-4a7f-a1a4-c4c8528a746f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb499953-e9ff-45bf-bae7-9e33017893a1");

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: new Guid("06703e74-5bd4-4efe-90e3-e3374560f8ba"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("eba061ee-cb3c-4cf3-ba33-3d2abeb94728"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb3ca938-28e9-4a7f-a1a4-c4c8528a746f");

            migrationBuilder.DeleteData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: new Guid("b2212d51-a8db-4382-b99a-4919d9f377ee"));

            migrationBuilder.DropColumn(
                name: "CurrentBid",
                table: "Lots");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "490ba9de-b38e-4f13-b811-4558f2e348b9", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsBlocked", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "039df29d-e213-454f-8888-edecff4c498c", 0, "cece9b74-3353-4014-a29e-0f5a0eab65b3", "peter@example.com", true, "Peter", false, "Parker", false, null, "PETER@EXAMPLE.COM", "PETER", "AQAAAAIAAYagAAAAEPbrwZgojF3Au/cNUlkaV2BLxLcV1aNTlD/Y83MpkKvsr0JEzJCiI/4Pn0rv0rnJ0w==", "+77771234567", true, "7b97acba-6bd1-4bcf-a319-e568f4890c9e", false, "peter" });

            migrationBuilder.InsertData(
                table: "Biddings",
                columns: new[] { "Id", "Bids", "CreatedAt", "FinalPrice", "IsBindingsStarted", "UpdatedAt" },
                values: new object[] { new Guid("528988a4-9a1f-48ba-b03f-640ba249a996"), 0.0m, new DateTime(2024, 5, 18, 18, 46, 36, 711, DateTimeKind.Local).AddTicks(5351), 1000.0m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "BiddingId", "CreatedAt", "Description", "Images", "IsArchived", "IsStarted", "Name", "StartPrice", "Tags", "TradingDuration", "TradingStart", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("b7ddd2d0-dfa4-46e3-a475-6e8b62cf3a87"), new Guid("528988a4-9a1f-48ba-b03f-640ba249a996"), new DateTime(2024, 5, 18, 18, 46, 36, 711, DateTimeKind.Local).AddTicks(5370), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", false, false, "Lot #1", 937.1m, "Test", new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "039df29d-e213-454f-8888-edecff4c498c" });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "CreatedAt", "Currency", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("71e112f9-442a-4626-bc5b-09d71895e30b"), 1000000.0m, new DateTime(2024, 5, 18, 18, 46, 36, 711, DateTimeKind.Local).AddTicks(5327), "Kaspi Coin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "039df29d-e213-454f-8888-edecff4c498c" });
        }
    }
}
