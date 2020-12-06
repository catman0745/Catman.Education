using Microsoft.EntityFrameworkCore.Migrations;

namespace Catman.Education.Persistence.Migrations
{
    using System;

    internal class DivideUsersToAdminsAndStudentsTPH
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_users_group_id",
                table: "users",
                column: "group_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_groups_group_id",
                table: "users",
                column: "group_id",
                principalTable: "groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_groups_group_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_group_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "users");

            migrationBuilder.DropColumn(
                name: "full_name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "group_id",
                table: "users");
        }
    }

    internal class SetUserDiscriminatorBasedOnRole
    {
        private const string PostgreSQLCommand = @"UPDATE users
                                                   SET ""Discriminator"" = CASE
                                                       WHEN role = 'stud' THEN 'Student'
                                                       WHEN role = 'admin' THEN 'Admin'
                                                   END;";
        
        public static void Up(MigrationBuilder migrationBuilder)
        {
            var sqlCommand = migrationBuilder.ActiveProvider switch
            {
                "Npgsql.EntityFrameworkCore.PostgreSQL" => PostgreSQLCommand,
                _ => throw new Exception("Unexpected provider")
            };
            migrationBuilder.Sql(sqlCommand);
        }
    }

    internal class RemoveUserRole
    {
        private const string PostgreSQLCommand = @"UPDATE users
                                                   SET role = CASE
                                                       WHEN ""Discriminator"" = 'Admin' THEN 'admin'
                                                       WHEN ""Discriminator"" = 'Student' THEN 'stud'
                                                   END;";
    
        public static void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "users");
        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            var sqlCommand = migrationBuilder.ActiveProvider switch
            {
                "Npgsql.EntityFrameworkCore.PostgreSQL" => PostgreSQLCommand,
                _ => throw new Exception("Unexpected provider")
            };
            
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "users",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "stud");
            
            migrationBuilder.Sql(sqlCommand);
        }
    }

    internal class SetStudentFullNameBasedOnUsername
    {
        private const string PostgreSQLCommand = @"UPDATE users
                                                   SET full_name = username
                                                   WHERE ""Discriminator"" = 'Student'";
        
        public static void Up(MigrationBuilder migrationBuilder)
        {
            var sqlCommand = migrationBuilder.ActiveProvider switch
            {
                "Npgsql.EntityFrameworkCore.PostgreSQL" => PostgreSQLCommand,
                _ => throw new Exception("Unexpected provider")
            };
            migrationBuilder.Sql(sqlCommand);
        }
    }

    internal class AssignStudentsToDummyGroup
    {
        private const string UpPostgreSQLCommand = @"INSERT INTO groups(id, title)
                                                     SELECT '07450745-0745-0745-0745-074507450745', 'DUMMY'
                                                     WHERE EXISTS (SELECT * FROM users
                                                                   WHERE ""Discriminator"" = 'Student');
                                                     UPDATE users
                                                     SET group_id = '07450745-0745-0745-0745-074507450745'
                                                     WHERE ""Discriminator"" = 'Student'";

        private const string DownPostgreSQLCommand = @"UPDATE users
                                                       SET group_id = NULL
                                                       WHERE group_id = '07450745-0745-0745-0745-074507450745';
                                                       DELETE FROM groups
                                                       WHERE id = '07450745-0745-0745-0745-074507450745'";
        
        public static void Up(MigrationBuilder migrationBuilder)
        {
            var sqlCommand = migrationBuilder.ActiveProvider switch
            {
                "Npgsql.EntityFrameworkCore.PostgreSQL" => UpPostgreSQLCommand,
                _ => throw new Exception("Unexpected provider")
            };
            migrationBuilder.Sql(sqlCommand);
        }
        
        public static void Down(MigrationBuilder migrationBuilder)
        {
            var sqlCommand = migrationBuilder.ActiveProvider switch
            {
                "Npgsql.EntityFrameworkCore.PostgreSQL" => DownPostgreSQLCommand,
                _ => throw new Exception("Unexpected provider")
            };
            migrationBuilder.Sql(sqlCommand);
        }
    }
    
    public partial class DivideUsersIntoStudentsAndAdmins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            DivideUsersToAdminsAndStudentsTPH.Up(migrationBuilder);
            SetUserDiscriminatorBasedOnRole.Up(migrationBuilder);
            RemoveUserRole.Up(migrationBuilder);
            SetStudentFullNameBasedOnUsername.Up(migrationBuilder);
            AssignStudentsToDummyGroup.Up(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            AssignStudentsToDummyGroup.Down(migrationBuilder);
            RemoveUserRole.Down(migrationBuilder);
            DivideUsersToAdminsAndStudentsTPH.Down(migrationBuilder);
        }
    }
}
