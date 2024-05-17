using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.Migrations
{
    /// <inheritdoc />
    public partial class RefactorContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Biddings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "caeca804-ae61-4674-b9fe-3da55e6f2211", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsBlocked", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "59c0877c-fe48-4701-97bd-0a8dd90ff67d", 0, "8d9e7ff1-6e2a-44c8-ba95-654531a79938", "peter@example.com", true, "Peter", false, "Parker", false, null, "PETER@EXAMPLE.COM", "PETER", "AQAAAAIAAYagAAAAEEbWM8yqyNcJ8qO1IPPQuIwNbCH4KliANIbNjmPaDyDXlhQah2FQgacLJxAJpOMOwg==", "+77771234567", true, "7b97acba-6bd1-4bcf-a319-e568f4890c9e", false, "peter" });

            migrationBuilder.InsertData(
                table: "Biddings",
                columns: new[] { "Id", "Bid", "CreatedAt", "FinalPrice", "IsArchived", "UpdatedAt" },
                values: new object[] { new Guid("72662b33-af50-4a22-b681-63262824a47c"), 0.0m, new DateTime(2024, 5, 18, 0, 2, 12, 110, DateTimeKind.Local).AddTicks(3792), 1000.0m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "Id", "BiddingId", "CreatedAt", "Description", "Images", "Name", "StartPrice", "Tags", "TradingDuration", "TradingStart", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("7a73a039-5f8c-455a-842d-3182bc5cfe55"), new Guid("72662b33-af50-4a22-b681-63262824a47c"), new DateTime(2024, 5, 18, 0, 2, 12, 110, DateTimeKind.Local).AddTicks(3818), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Earum, voluptas!", "https://img.freepik.com/free-photo/close-up-on-kitten-surrounded-by-flowers_23-2150782329.jpg?size=626&ext=jpg&ga=GA1.1.1413502914.1715558400&semt=ais_user", "Lot #1", 937.1m, "Test", new DateTime(2020, 2, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "59c0877c-fe48-4701-97bd-0a8dd90ff67d" });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "CreatedAt", "Currency", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("2ee58dff-8169-4658-a564-b9dfd0478f78"), 1000000.0m, new DateTime(2024, 5, 18, 0, 2, 12, 110, DateTimeKind.Local).AddTicks(3756), "Kaspi Coin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "59c0877c-fe48-4701-97bd-0a8dd90ff67d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caeca804-ae61-4674-b9fe-3da55e6f2211");

            migrationBuilder.DeleteData(
                table: "Lots",
                keyColumn: "Id",
                keyValue: new Guid("7a73a039-5f8c-455a-842d-3182bc5cfe55"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("2ee58dff-8169-4658-a564-b9dfd0478f78"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59c0877c-fe48-4701-97bd-0a8dd90ff67d");

            migrationBuilder.DeleteData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: new Guid("72662b33-af50-4a22-b681-63262824a47c"));

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Biddings");

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
    }
}
