using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperTeamApp.Data.Migrations
{
    public partial class AddSomethingToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FPrice",
                table: "Foodprices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FPrice",
                table: "Foodprices");
        }
    }
}
