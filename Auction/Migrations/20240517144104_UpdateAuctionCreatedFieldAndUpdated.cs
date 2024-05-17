using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuctionCreatedFieldAndUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74d0f91a-fc1a-4e20-854d-ed6d01c0a4e7");

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: new Guid("5ab2bf67-73e1-4781-abe5-b85b2aa792a7"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("1e79eb10-568f-4321-a85e-df5ab45deb0f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7a801c7-8030-4b91-aca3-30d5c627734d");

            migrationBuilder.DeleteData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: new Guid("54d936db-4831-4664-8cb0-5df648714ff7"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Wallets",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Lots",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Lots",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Biddings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Biddings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8d4e2b4-0c5d-4377-a8c6-22fe6f2c9913", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsBlocked", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "af6cf668-f1c4-4ef6-ab21-438c3b0d4875", 0, "e2bda8a8-9ead-4039-a648-5e7d7a45eae7", "peter@example.com", true, "Peter", false, "Parker", false, null, "PETER@EXAMPLE.COM", "PETER", "AQAAAAIAAYagAAAAEG0M/u3JjS0FmCDbHToRoxyDXUNOQAeHa+iPt67ZyYLvjARhv5HT8mU8FaalwnypWA==", "+77771234567", true, "7b97acba-6bd1-4bcf-a319-e568f4890c9e", false, "peter" });

            migrationBuilder.InsertData(
                table: "Biddings",
                columns: new[] { "Id", "Bid", "CreatedAt", "FinalPrice", "UpdatedAt" },
                values: new object[] { new Guid("f3916bd2-671c-4c19-897c-e723f4058695"), 0.0m, new DateTime(2024, 5, 17, 19, 41, 4, 94, DateTimeKind.Local).AddTicks(2386), 1000.0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "BiddingId", "CreatedAt", "Description", "Images", "Name", "StartPrice", "Tags", "TradingDuration", "TradingStart", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("f4d4172b-071c-4c1c-9a93-273755343117"), new Guid("f3916bd2-671c-4c19-897c-e723f4058695"), new DateTime(2024, 5, 17, 19, 41, 4, 94, DateTimeKind.Local).AddTicks(2451), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new DateTime(2020, 2, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "af6cf668-f1c4-4ef6-ab21-438c3b0d4875" });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "CreatedAt", "Currency", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("55d24087-8680-479f-a4c9-cfa144c0a104"), 1000000.0m, new DateTime(2024, 5, 17, 19, 41, 4, 94, DateTimeKind.Local).AddTicks(2349), "Kaspi Coin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "af6cf668-f1c4-4ef6-ab21-438c3b0d4875" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8d4e2b4-0c5d-4377-a8c6-22fe6f2c9913");

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: new Guid("f4d4172b-071c-4c1c-9a93-273755343117"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("55d24087-8680-479f-a4c9-cfa144c0a104"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af6cf668-f1c4-4ef6-ab21-438c3b0d4875");

            migrationBuilder.DeleteData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: new Guid("f3916bd2-671c-4c19-897c-e723f4058695"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Biddings");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Biddings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74d0f91a-fc1a-4e20-854d-ed6d01c0a4e7", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsBlocked", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7a801c7-8030-4b91-aca3-30d5c627734d", 0, "f8c488aa-953f-4de0-98db-996afeb78e7a", "peter@example.com", true, "Peter", false, "Parker", false, null, "PETER@EXAMPLE.COM", "PETER", "AQAAAAIAAYagAAAAELtjpBnU3lMumjwGZx61GwIRm3/SmX9LZKl6lVx0GtJrFTwcWUYLfkXZtazd1+dlwg==", "+77771234567", true, "7b97acba-6bd1-4bcf-a319-e568f4890c9e", false, "peter" });

            migrationBuilder.InsertData(
                table: "Biddings",
                columns: new[] { "Id", "Bid", "FinalPrice" },
                values: new object[] { new Guid("54d936db-4831-4664-8cb0-5df648714ff7"), 0.0m, 1000.0m });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "BiddingId", "Description", "Images", "Name", "StartPrice", "Tags", "TradingDuration", "TradingStart", "UserId" },
                values: new object[] { new Guid("5ab2bf67-73e1-4781-abe5-b85b2aa792a7"), new Guid("54d936db-4831-4664-8cb0-5df648714ff7"), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new DateTime(2020, 2, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "c7a801c7-8030-4b91-aca3-30d5c627734d" });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "Currency", "UserId" },
                values: new object[] { new Guid("1e79eb10-568f-4321-a85e-df5ab45deb0f"), 1000000.0m, "Kaspi Coin", "c7a801c7-8030-4b91-aca3-30d5c627734d" });
        }
    }
}
