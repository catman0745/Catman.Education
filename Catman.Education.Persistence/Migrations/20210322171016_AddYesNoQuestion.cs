using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catman.Education.Persistence.Migrations
{
    public partial class AddYesNoQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "yes_no_questions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    correct_answer = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yes_no_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_yes_no_questions_questions_id",
                        column: x => x.id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "yes_no_questions");
        }
    }
}
