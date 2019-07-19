using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class addtags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataTableId",
                table: "modelWell");

            migrationBuilder.DropColumn(
                name: "DataTableId",
                table: "modelTarget");

            migrationBuilder.CreateTable(
                name: "tagsTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tagsTable", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tagsTable");

            migrationBuilder.AddColumn<int>(
                name: "DataTableId",
                table: "modelWell",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataTableId",
                table: "modelTarget",
                nullable: true);
        }
    }
}
