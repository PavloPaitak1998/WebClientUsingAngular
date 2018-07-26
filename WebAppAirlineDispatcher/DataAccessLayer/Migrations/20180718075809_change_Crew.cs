using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class change_Crew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pilots_CrewId",
                table: "Pilots");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_CrewId",
                table: "Pilots",
                column: "CrewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pilots_CrewId",
                table: "Pilots");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_CrewId",
                table: "Pilots",
                column: "CrewId",
                unique: true);
        }
    }
}
