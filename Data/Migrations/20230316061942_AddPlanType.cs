using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewBTC.Data.Migrations
{
    public partial class AddPlanType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedDuration",
                table: "InvestmentP");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "InvestmentP",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "InvestmentP");

            migrationBuilder.AddColumn<string>(
                name: "SelectedDuration",
                table: "InvestmentP",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
