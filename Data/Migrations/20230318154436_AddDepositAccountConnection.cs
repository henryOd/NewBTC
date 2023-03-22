using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewBTC.Data.Migrations
{
    public partial class AddDepositAccountConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Account",
                newName: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Account",
                newName: "Id");
        }
    }
}
