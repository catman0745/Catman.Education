using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catman.Education.Persistence.Migrations
{
    public partial class AddQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    text = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false),
                    cost = table.Column<int>(type: "integer", nullable: false),
                    test_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_questions_tests_test_id",
                        column: x => x.test_id,
                        principalTable: "tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_test_id",
                table: "questions",
                column: "test_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questions");
        }
    }
}
