using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SeedLogEventsAndLogLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LogEvents",
                columns: new[] { "Id", "CodeId", "Name" },
                values: new object[,]
                {
                    { 1, 1000, "GenerateItems" },
                    { 11, 3002, "ErrorUploadItem" },
                    { 10, 3001, "UploadItem" },
                    { 8, 2001, "ErrorEmailSent" },
                    { 7, 2000, "EmailSent" },
                    { 9, 3000, "TestItem" },
                    { 5, 1004, "UpdateItem" },
                    { 4, 1003, "InsertItem" },
                    { 3, 1002, "GetItem" },
                    { 2, 1001, "ListItems" },
                    { 6, 1005, "DeleteItem" }
                });

            migrationBuilder.InsertData(
                table: "LogLevels",
                columns: new[] { "Id", "CodeId", "Name" },
                values: new object[,]
                {
                    { 6, 5, "Critical" },
                    { 1, 0, "Trace" },
                    { 2, 1, "Debug" },
                    { 3, 2, "Information" },
                    { 4, 3, "Warning" },
                    { 5, 4, "Error" },
                    { 7, 6, "None" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LogEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LogEvents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LogEvents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LogEvents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LogEvents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LogEvents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LogEvents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LogEvents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LogEvents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LogEvents",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LogEvents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LogLevels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LogLevels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LogLevels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LogLevels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LogLevels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LogLevels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LogLevels",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
