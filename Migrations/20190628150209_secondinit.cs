using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class secondinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_modelTag_dataresultTable_DataID",
                table: "modelTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_modelTag",
                table: "modelTag");

            migrationBuilder.RenameTable(
                name: "modelTag",
                newName: "tagsTable");

            migrationBuilder.RenameIndex(
                name: "IX_modelTag_DataID",
                table: "tagsTable",
                newName: "IX_tagsTable_DataID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tagsTable",
                table: "tagsTable",
                column: "ID");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_tagsTable",
                table: "tagsTable");

            migrationBuilder.RenameTable(
                name: "tagsTable",
                newName: "modelTag");

            migrationBuilder.RenameIndex(
                name: "IX_tagsTable_DataID",
                table: "modelTag",
                newName: "IX_modelTag_DataID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_modelTag",
                table: "modelTag",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_modelTag_dataresultTable_DataID",
                table: "modelTag",
                column: "DataID",
                principalTable: "dataresultTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
