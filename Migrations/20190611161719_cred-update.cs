using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class credupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "sysadmin",
                table: "credentialsTable",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sysadmin",
                table: "credentialsTable");
        }
    }
}
