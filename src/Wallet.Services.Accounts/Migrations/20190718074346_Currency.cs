using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.Services.Accounts.Migrations
{
    public partial class Currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Account",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CurrencySymbol",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyTitle",
                table: "Account",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CurrencySymbol",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CurrencyTitle",
                table: "Account");
        }
    }
}
