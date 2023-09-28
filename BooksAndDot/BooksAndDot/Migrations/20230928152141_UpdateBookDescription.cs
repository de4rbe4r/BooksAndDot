using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAndDot.Migrations
{
    public partial class UpdateBookDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Books_BookId",
                table: "Cover");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Cover",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cover_Books_BookId",
                table: "Cover",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Books_BookId",
                table: "Cover");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Cover",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cover_Books_BookId",
                table: "Cover",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
