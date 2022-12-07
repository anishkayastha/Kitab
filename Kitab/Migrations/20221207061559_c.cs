using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitab.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Books_Authors_AuthorId",
                table: "Categories_Books");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Books_AuthorId",
                table: "Categories_Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Categories_Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Categories_Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Books_AuthorId",
                table: "Categories_Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Books_Authors_AuthorId",
                table: "Categories_Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }
    }
}
