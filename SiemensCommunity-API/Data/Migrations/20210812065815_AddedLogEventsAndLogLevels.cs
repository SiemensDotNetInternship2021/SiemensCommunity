using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddedLogEventsAndLogLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogLevel",
                table: "Logs",
                newName: "LogLevelId");

            migrationBuilder.RenameColumn(
                name: "LogEvent",
                table: "Logs",
                newName: "LogEventId");

            migrationBuilder.CreateTable(
                name: "LogEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogLevels", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Logs_LogEventId",
                table: "Logs",
                column: "LogEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_LogLevelId",
                table: "Logs",
                column: "LogLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_LogEvents_LogEventId",
                table: "Logs",
                column: "LogEventId",
                principalTable: "LogEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_LogLevels_LogLevelId",
                table: "Logs",
                column: "LogLevelId",
                principalTable: "LogLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_LogEvents_LogEventId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_LogLevels_LogLevelId",
                table: "Logs");

            migrationBuilder.DropTable(
                name: "LogEvents");

            migrationBuilder.DropTable(
                name: "LogLevels");

            migrationBuilder.DropIndex(
                name: "IX_Logs_LogEventId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_LogLevelId",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "LogLevelId",
                table: "Logs",
                newName: "LogLevel");

            migrationBuilder.RenameColumn(
                name: "LogEventId",
                table: "Logs",
                newName: "LogEvent");
        }
    }
}
