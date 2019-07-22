using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.Services.Transactions.Migrations
{
    public partial class accountsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Accounts");
        }
    }
}
