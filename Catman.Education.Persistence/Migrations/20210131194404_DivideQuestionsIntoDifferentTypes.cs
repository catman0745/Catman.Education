using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catman.Education.Persistence.Migrations
{
    public partial class DivideQuestionsIntoDifferentTypes : Migration
    {
        private static void DataUp(MigrationBuilder migrationBuilder)
        {
            var sqlCommand = migrationBuilder.ActiveProvider switch
            {
                "Npgsql.EntityFrameworkCore.PostgreSQL" => @"INSERT INTO multiple_choice_questions(id)
                                                             SELECT id FROM questions;
                                                             INSERT INTO question_items(id, text, question_id)
                                                             SELECT id, text, question_id FROM answers;
                                                             INSERT INTO multiple_choice_question_answer_options(id, is_correct, multiple_choice_question_id)
                                                             SELECT id, is_correct, question_id FROM answers;",
                _ => throw new Exception("Unexpected provider")
            };
            migrationBuilder.Sql(sqlCommand);
        }
        
        private static void DataDown(MigrationBuilder migrationBuilder)
        {
            var sqlCommand = migrationBuilder.ActiveProvider switch
            {
                "Npgsql.EntityFrameworkCore.PostgreSQL" => @"INSERT INTO answers(id, text, is_correct, question_id)
                                                             SELECT question_items.id, text, is_correct, question_id
                                                             FROM question_items
                                                             JOIN multiple_choice_question_answer_options
                                                             ON question_items.id = multiple_choice_question_answer_options.id;",
                _ => throw new Exception("Unexpected provider")
            };
            migrationBuilder.Sql(sqlCommand);
        }
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "multiple_choice_questions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_multiple_choice_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_multiple_choice_questions_questions_id",
                        column: x => x.id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    text = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_question_items_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "multiple_choice_question_answer_options",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false),
                    multiple_choice_question_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_multiple_choice_question_answer_options", x => x.id);
                    table.ForeignKey(
                        name: "FK_multiple_choice_question_answer_options_multiple_choice_que~",
                        column: x => x.multiple_choice_question_id,
                        principalTable: "multiple_choice_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_multiple_choice_question_answer_options_question_items_id",
                        column: x => x.id,
                        principalTable: "question_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_multiple_choice_question_answer_options_multiple_choice_que~",
                table: "multiple_choice_question_answer_options",
                column: "multiple_choice_question_id");

            migrationBuilder.CreateIndex(
                name: "IX_question_items_question_id",
                table: "question_items",
                column: "question_id");

            DataUp(migrationBuilder);
            
            migrationBuilder.DropTable(
                name: "answers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    text = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answers", x => x.id);
                    table.ForeignKey(
                        name: "FK_answers_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_answers_question_id",
                table: "answers",
                column: "question_id");

            DataDown(migrationBuilder);
            
            migrationBuilder.DropTable(
                name: "multiple_choice_question_answer_options");

            migrationBuilder.DropTable(
                name: "multiple_choice_questions");

            migrationBuilder.DropTable(
                name: "question_items");
        }
    }
}
