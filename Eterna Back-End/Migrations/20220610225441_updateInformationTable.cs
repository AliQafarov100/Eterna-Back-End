using Microsoft.EntityFrameworkCore.Migrations;

namespace Eterna_Back_End.Migrations
{
    public partial class updateInformationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_informations_Progresses_ProgressId",
                table: "informations");

            migrationBuilder.DropIndex(
                name: "IX_informations_ProgressId",
                table: "informations");

            migrationBuilder.DropColumn(
                name: "ProgressId",
                table: "informations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgressId",
                table: "informations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_informations_ProgressId",
                table: "informations",
                column: "ProgressId");

            migrationBuilder.AddForeignKey(
                name: "FK_informations_Progresses_ProgressId",
                table: "informations",
                column: "ProgressId",
                principalTable: "Progresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
