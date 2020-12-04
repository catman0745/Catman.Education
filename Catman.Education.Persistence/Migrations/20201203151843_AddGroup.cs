using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catman.Education.Persistence.Migrations
{
    public partial class AddGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_groups_title",
                table: "groups",
                column: "title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "groups");
        }
    }
}
