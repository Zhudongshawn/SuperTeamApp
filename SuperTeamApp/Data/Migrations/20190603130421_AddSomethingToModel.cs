using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperTeamApp.Data.Migrations
{
    public partial class AddSomethingToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FPrice",
                table: "Inquiryoffices",
                newName: "Question");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Inquiryoffices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Inquiryoffices");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Inquiryoffices",
                newName: "FPrice");
        }
    }
}
