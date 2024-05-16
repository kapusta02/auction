using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Auction.Migrations.Auction
{
    /// <inheritdoc />
    public partial class UpdateIdentitySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", maxLength: 36, nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "Id", "Balance", "Currency", "UserId" },
                values: new object[,]
                {
                    { new Guid("8355754f-f38f-4873-a247-8155b74a51a0"), 1000000.0m, "Kaspi Coin", new Guid("5c434df2-8a95-48df-9d5c-81f5adffcef8") },
                    { new Guid("a19a5d66-42e8-4e47-8201-96337152f06c"), 1004300.0m, "Kaspi Coin", new Guid("65b5e8da-8a81-42e8-b307-5596a2f53df5") },
                    { new Guid("a88c32a7-72a7-4aeb-885a-97168d4630a9"), 1023100.0m, "Kaspi Coin", new Guid("6bfb27fc-492a-41b5-8e84-a76447ab6b36") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_Id",
                table: "Wallet",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallet");
        }
    }
}
