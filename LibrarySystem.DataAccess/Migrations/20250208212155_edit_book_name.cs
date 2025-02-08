using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class edit_book_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowed_Book_table_BookId",
                table: "Borrowed_Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_table",
                table: "table");

            migrationBuilder.RenameTable(
                name: "table",
                newName: "Book");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowed_Book_Book_BookId",
                table: "Borrowed_Book",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowed_Book_Book_BookId",
                table: "Borrowed_Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "table");

            migrationBuilder.AddPrimaryKey(
                name: "PK_table",
                table: "table",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowed_Book_table_BookId",
                table: "Borrowed_Book",
                column: "BookId",
                principalTable: "table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
