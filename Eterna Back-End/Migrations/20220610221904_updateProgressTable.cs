using Microsoft.EntityFrameworkCore.Migrations;

namespace Eterna_Back_End.Migrations
{
    public partial class updateProgressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ProgressValueMax",
                table: "Progresses",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ProgressValueMin",
                table: "Progresses",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ProgressValueNow",
                table: "Progresses",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgressValueMax",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "ProgressValueMin",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "ProgressValueNow",
                table: "Progresses");
        }
    }
}
