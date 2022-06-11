using Microsoft.EntityFrameworkCore.Migrations;

namespace Eterna_Back_End.Migrations
{
    public partial class addProgressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "DescriptionTitle",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "MainTitle",
                table: "Progresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Progresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionTitle",
                table: "Progresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Progresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainTitle",
                table: "Progresses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
