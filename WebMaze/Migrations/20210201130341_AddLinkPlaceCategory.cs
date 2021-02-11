using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class AddLinkPlaceCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "RestPlace",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestPlace_CategoryId",
                table: "RestPlace",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestPlace_RestCategory_CategoryId",
                table: "RestPlace",
                column: "CategoryId",
                principalTable: "RestCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestPlace_RestCategory_CategoryId",
                table: "RestPlace");

            migrationBuilder.DropIndex(
                name: "IX_RestPlace_CategoryId",
                table: "RestPlace");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "RestPlace");
        }
    }
}
