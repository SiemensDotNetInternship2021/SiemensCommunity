using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class BorrowedProductMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorrowedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedProducts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BorrowedProducts",
                columns: new[] { "Id", "EndDate", "ProductId", "StartDate", "UserId" },
                values: new object[] { 1, "2021/7/23", 4, "2021/7/13", 2 });

            migrationBuilder.InsertData(
                table: "BorrowedProducts",
                columns: new[] { "Id", "EndDate", "ProductId", "StartDate", "UserId" },
                values: new object[] { 2, "2021/7/23", 4, "2021/7/13", 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsAvailable",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedProducts");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsAvailable",
                value: true);
        }
    }
}
