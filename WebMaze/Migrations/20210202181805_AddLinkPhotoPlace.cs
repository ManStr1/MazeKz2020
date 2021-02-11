using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class AddLinkPhotoPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PlaceId",
                table: "RestPhoto",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestPhoto_PlaceId",
                table: "RestPhoto",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestPhoto_RestPlace_PlaceId",
                table: "RestPhoto",
                column: "PlaceId",
                principalTable: "RestPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestPhoto_RestPlace_PlaceId",
                table: "RestPhoto");

            migrationBuilder.DropIndex(
                name: "IX_RestPhoto_PlaceId",
                table: "RestPhoto");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "RestPhoto");
        }
    }
}
