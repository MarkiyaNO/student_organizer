using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentOrganizer.DAL.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Schedules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleType",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonType",
                table: "ScheduleLessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "ScheduleLessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "ScheduleLessons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ScheduleType",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "LessonType",
                table: "ScheduleLessons");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "ScheduleLessons");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "ScheduleLessons");
        }
    }
}
