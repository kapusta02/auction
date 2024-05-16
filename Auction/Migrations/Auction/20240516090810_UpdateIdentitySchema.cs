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
                    { new Guid("1b7996fc-de72-40b2-9269-696d7b9e006a"), 1004300.0m, "Kaspi Coin", new Guid("af0210b8-2099-472b-af87-7d744d647f0f") },
                    { new Guid("9d9db672-3e4d-43e5-88a3-94c846485539"), 1000000.0m, "Kaspi Coin", new Guid("97378ce5-3ed6-464e-a930-492ed0b9ff91") },
                    { new Guid("e63fd150-c84a-47a5-b054-93e4c01f583f"), 1023100.0m, "Kaspi Coin", new Guid("b3a38103-36b7-4ec7-b50f-68f914bf4d1b") }
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
