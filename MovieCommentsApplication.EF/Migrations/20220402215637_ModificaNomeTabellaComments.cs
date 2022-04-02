using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCommentsApplication.EF.Migrations
{
    public partial class ModificaNomeTabellaComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_movie_comment",
                table: "movie_comment");

            migrationBuilder.RenameTable(
                name: "movie_comment",
                newName: "comments");

            migrationBuilder.RenameColumn(
                name: "comment_text",
                table: "comments",
                newName: "comment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "movie_comment");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "movie_comment",
                newName: "comment_text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie_comment",
                table: "movie_comment",
                column: "id");
        }
    }
}
