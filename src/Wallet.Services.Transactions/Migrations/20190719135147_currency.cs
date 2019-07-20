using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.Services.Transactions.Migrations
{
    public partial class currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountTitle",
                table: "Transactions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyTitle",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountTitle",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CurrencyTitle",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transactions");
        }
    }
}
