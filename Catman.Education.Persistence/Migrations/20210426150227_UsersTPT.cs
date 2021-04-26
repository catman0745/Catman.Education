using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catman.Education.Persistence.Migrations
{
    public partial class UsersTPT : Migration
    {
        private static void DataUp(MigrationBuilder migrationBuilder)
        {
            var sqlCommand = migrationBuilder.ActiveProvider switch
            {
                "Npgsql.EntityFrameworkCore.PostgreSQL" => @"INSERT INTO admins(id)
                                                             SELECT id FROM users
                                                             WHERE role = 'Admin';
                                                             INSERT INTO students(id, full_name, group_id)
                                                             SELECT id, full_name, group_id FROM users
                                                             WHERE role = 'Student';",
                _ => throw new Exception("Unexpected provider")
            };
            migrationBuilder.Sql(sqlCommand);
        }
        
        private static void DataDown(MigrationBuilder migrationBuilder)
        {
            var sqlCommand = migrationBuilder.ActiveProvider switch
            {
                "Npgsql.EntityFrameworkCore.PostgreSQL" => @"UPDATE users
                                                             SET full_name = student.full_name,
                                                                 group_id = student.group_id,
                                                                 ""role"" = 'Student'
                                                             FROM (SELECT * FROM students) AS student
                                                             WHERE users.id = student.id;
                                                             UPDATE users
                                                             SET role = 'Admin'
                                                             WHERE role <> 'Student';",
                _ => throw new Exception("Unexpected provider")
            };
            migrationBuilder.Sql(sqlCommand);
        }
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.id);
                    table.ForeignKey(
                        name: "FK_admins_users_id",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    group_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_students_users_id",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_group_id",
                table: "students",
                column: "group_id");
            
            DataUp(migrationBuilder);

            migrationBuilder.AddForeignKey(
                name: "FK_testing_results_students_student_id",
                table: "testing_results",
                column: "student_id",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            
            migrationBuilder.DropForeignKey(
                name: "FK_testing_results_users_student_id",
                table: "testing_results");

            migrationBuilder.DropForeignKey(
                name: "FK_users_groups_group_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_group_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "full_name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "group_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "role",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "users",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "group_id",
                table: "users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_users_group_id",
                table: "users",
                column: "group_id");

            migrationBuilder.AddForeignKey(
                name: "FK_testing_results_users_student_id",
                table: "testing_results",
                column: "student_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_groups_group_id",
                table: "users",
                column: "group_id",
                principalTable: "groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            
            DataDown(migrationBuilder);
            
            migrationBuilder.DropForeignKey(
                name: "FK_testing_results_students_student_id",
                table: "testing_results");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
