using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewBTC.Data.Migrations
{
    public partial class AddDateDeposited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Deposits");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeposited",
                table: "Deposits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDeposited",
                table: "Deposits");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Deposits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
