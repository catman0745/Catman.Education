using Microsoft.EntityFrameworkCore.Migrations;

namespace Catman.Education.Persistence.Migrations
{
    public partial class RenameMultipleChoiceQuestionIntoChoiceQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_multiple_choice_questions_questions_id",
                table: "multiple_choice_questions");
            migrationBuilder.DropForeignKey(
                name: "FK_multiple_choice_question_answer_options_multiple_choice_que~",
                table: "multiple_choice_question_answer_options");
            migrationBuilder.DropForeignKey(
                name: "FK_multiple_choice_question_answer_options_question_items_id",
                table: "multiple_choice_question_answer_options");
            
            migrationBuilder.RenameTable(name: "multiple_choice_questions", newName: "choice_questions");
            migrationBuilder.RenameIndex(name: "PK_multiple_choice_questions", newName: "PK_choice_questions");
            
            migrationBuilder.RenameTable(
                name: "multiple_choice_question_answer_options",
                newName: "choice_question_answer_options");
            migrationBuilder.RenameColumn(
                name: "multiple_choice_question_id",
                table: "choice_question_answer_options",
                newName: "choice_question_id");
            migrationBuilder.RenameIndex(
                name: "PK_multiple_choice_question_answer_options",
                newName: "PK_choice_question_answer_options");
            migrationBuilder.RenameIndex(
                name: "IX_multiple_choice_question_answer_options_multiple_choice_que~",
                newName: "IX_choice_question_answer_options_choice_question_id");

            
            migrationBuilder.AddForeignKey(
                name: "FK_choice_questions_questions_id",
                table: "choice_questions",
                column: "id",
                principalTable: "questions",
                principalColumn: "id");
            migrationBuilder.AddForeignKey(
                name: "FK_choice_question_answer_options_choice_questions_choice_ques~",
                table: "choice_question_answer_options",
                column: "choice_question_id",
                principalTable: "choice_questions",
                principalColumn: "id");
            migrationBuilder.AddForeignKey(
                name: "FK_choice_question_answer_options_question_items_id",
                table: "choice_question_answer_options",
                column: "id",
                principalTable: "question_items",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_choice_questions_questions_id",
                table: "choice_questions");
            migrationBuilder.DropForeignKey(
                name: "FK_choice_question_answer_options_choice_questions_choice_ques~",
                table: "choice_question_answer_options");
            migrationBuilder.DropForeignKey(
                name: "FK_choice_question_answer_options_question_items_id",
                table: "choice_question_answer_options");
            
            migrationBuilder.RenameTable(name: "choice_questions", newName: "multiple_choice_questions");
            migrationBuilder.RenameIndex(name: "PK_choice_questions", newName: "PK_multiple_choice_questions");
            
            migrationBuilder.RenameTable(
                name: "choice_question_answer_options",
                newName: "multiple_choice_question_answer_options");
            migrationBuilder.RenameColumn(
                name: "choice_question_id",
                table: "multiple_choice_question_answer_options",
                newName: "multiple_choice_question_id");
            migrationBuilder.RenameIndex(
                name: "PK_choice_question_answer_options",
                newName: "PK_multiple_choice_question_answer_options");
            migrationBuilder.RenameIndex(
                name: "IX_choice_question_answer_options_choice_question_id",
                newName: "IX_multiple_choice_question_answer_options_multiple_choice_que~");
            
            migrationBuilder.AddForeignKey(
                name: "FK_multiple_choice_questions_questions_id",
                table: "multiple_choice_questions",
                column: "id",
                principalTable: "questions",
                principalColumn: "id");
            migrationBuilder.AddForeignKey(
                name: "FK_multiple_choice_question_answer_options_multiple_choice_que~",
                table: "multiple_choice_question_answer_options",
                column: "multiple_choice_question_id",
                principalTable: "multiple_choice_questions",
                principalColumn: "id");
            migrationBuilder.AddForeignKey(
                name: "FK_multiple_choice_question_answer_options_question_items_id",
                table: "multiple_choice_question_answer_options",
                column: "id",
                principalTable: "question_items",
                principalColumn: "id");
        }
    }
}
