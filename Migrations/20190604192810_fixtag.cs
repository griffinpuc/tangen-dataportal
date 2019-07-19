using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class fixtag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tagsTable_dataresultTable_modelDataResultID",
                table: "tagsTable");

            migrationBuilder.RenameColumn(
                name: "modelDataResultID",
                table: "tagsTable",
                newName: "DataID");

            migrationBuilder.RenameIndex(
                name: "IX_tagsTable_modelDataResultID",
                table: "tagsTable",
                newName: "IX_tagsTable_DataID");

            migrationBuilder.AddForeignKey(
                name: "FK_tagsTable_dataresultTable_DataID",
                table: "tagsTable",
                column: "DataID",
                principalTable: "dataresultTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tagsTable_dataresultTable_DataID",
                table: "tagsTable");

            migrationBuilder.RenameColumn(
                name: "DataID",
                table: "tagsTable",
                newName: "modelDataResultID");

            migrationBuilder.RenameIndex(
                name: "IX_tagsTable_DataID",
                table: "tagsTable",
                newName: "IX_tagsTable_modelDataResultID");

            migrationBuilder.AddForeignKey(
                name: "FK_tagsTable_dataresultTable_modelDataResultID",
                table: "tagsTable",
                column: "modelDataResultID",
                principalTable: "dataresultTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
