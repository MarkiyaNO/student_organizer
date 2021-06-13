using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentOrganizer.DAL.Migrations
{
    public partial class MigrationDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Schedules");
        }
    }
}
