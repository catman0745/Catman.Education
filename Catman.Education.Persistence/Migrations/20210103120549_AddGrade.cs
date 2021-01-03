using Microsoft.EntityFrameworkCore.Migrations;

namespace Catman.Education.Persistence.Migrations
{
    public partial class AddGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "grade",
                table: "groups",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "grade",
                table: "disciplines",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_disciplines_grade_title",
                table: "disciplines",
                columns: new[] { "grade", "title" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_disciplines_grade_title",
                table: "disciplines");

            migrationBuilder.DropColumn(
                name: "grade",
                table: "groups");

            migrationBuilder.DropColumn(
                name: "grade",
                table: "disciplines");
        }
    }
}
