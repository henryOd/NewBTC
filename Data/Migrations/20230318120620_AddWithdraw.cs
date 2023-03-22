using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewBTC.Data.Migrations
{
    public partial class AddWithdraw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Withdraw",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    withdrawAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WithdrawDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AcctBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Wstatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdraw", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Withdraw");
        }
    }
}
