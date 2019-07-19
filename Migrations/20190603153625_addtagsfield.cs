using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class addtagsfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "modelDataResultID",
                table: "tagsTable",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tagsTable_modelDataResultID",
                table: "tagsTable",
                column: "modelDataResultID");

            migrationBuilder.AddForeignKey(
                name: "FK_tagsTable_dataresultTable_modelDataResultID",
                table: "tagsTable",
                column: "modelDataResultID",
                principalTable: "dataresultTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tagsTable_dataresultTable_modelDataResultID",
                table: "tagsTable");

            migrationBuilder.DropIndex(
                name: "IX_tagsTable_modelDataResultID",
                table: "tagsTable");

            migrationBuilder.DropColumn(
                name: "modelDataResultID",
                table: "tagsTable");
        }
    }
}
