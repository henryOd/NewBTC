using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewBTC.Data.Migrations
{
    public partial class AddSelectedListItemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "PlanType");

            migrationBuilder.CreateTable(
                name: "List<SelectListItem>",
                columns: table => new
                {
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "List<SelectListItem>");

            //migrationBuilder.CreateTable(
            //    name: "PlanType",
            //    columns: table => new
            //    {
            //    },
                //constraints: table =>
                //{
                //});
        }
    }
}
