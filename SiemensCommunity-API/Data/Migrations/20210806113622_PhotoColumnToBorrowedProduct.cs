using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PhotoColumnToBorrowedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "BorrowedProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "BorrowedProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedProducts_PhotoId",
                table: "BorrowedProducts",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedProducts_ProductId",
                table: "BorrowedProducts",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedProducts_Photos_PhotoId",
                table: "BorrowedProducts",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedProducts_Products_ProductId",
                table: "BorrowedProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedProducts_Photos_PhotoId",
                table: "BorrowedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedProducts_Products_ProductId",
                table: "BorrowedProducts");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedProducts_PhotoId",
                table: "BorrowedProducts");

            migrationBuilder.DropIndex(
                name: "IX_BorrowedProducts_ProductId",
                table: "BorrowedProducts");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "BorrowedProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "BorrowedProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
