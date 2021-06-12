namespace Catman.Education.Persistence.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;
    
    public partial class AddUserFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "users",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            DataUp(migrationBuilder);
            
            migrationBuilder.DropColumn(
                name: "full_name",
                table: "students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "students",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            DataDown(migrationBuilder);
            
            migrationBuilder.DropColumn(
                name: "full_name",
                table: "users");
        }

        private static void DataUp(MigrationBuilder migrationBuilder)
        {
            var sqlCommand = migrationBuilder.ActiveProvider switch
            {
                "Npgsql.EntityFrameworkCore.PostgreSQL" => @"UPDATE users
                                                             SET full_name = (
	                                                             SELECT COALESCE(s.full_name, u.username)
	                                                             FROM users u
	                                                             LEFT JOIN students s ON s.id = u.id
	                                                             WHERE u.id = users.id
                                                             )",
                _ => throw new Exception("Unexpected provider")
            };
            migrationBuilder.Sql(sqlCommand);
        }

        private static void DataDown(MigrationBuilder migrationBuilder)
        {
            var sqlCommand = migrationBuilder.ActiveProvider switch
            {
                "Npgsql.EntityFrameworkCore.PostgreSQL" => @"UPDATE students
                                                             SET full_name = users.full_name
                                                             FROM users
                                                             WHERE students.id = users.id",
                _ => throw new Exception("Unexpected provider")
            };
            migrationBuilder.Sql(sqlCommand);
        }
    }
}
