using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "credentialsTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    lastLogin = table.Column<string>(nullable: true),
                    sysadmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credentialsTable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "dataresultTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sampleID = table.Column<string>(nullable: true),
                    uniqueID = table.Column<string>(nullable: true),
                    downloadDateTime = table.Column<string>(nullable: true),
                    assayID = table.Column<string>(nullable: true),
                    kitLotID = table.Column<string>(nullable: true),
                    instrumentUUID = table.Column<string>(nullable: true),
                    instrumentName = table.Column<string>(nullable: true),
                    rawAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataresultTable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "instrumentsTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    localAddress = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    lastPing = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instrumentsTable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "rawindexTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    path = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rawindexTable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "trackersTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sampleID = table.Column<string>(nullable: true),
                    dateTime = table.Column<string>(nullable: true),
                    uniqueID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trackersTable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "modelTag",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true),
                    DataID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelTag", x => x.ID);
                    table.ForeignKey(
                        name: "FK_modelTag_dataresultTable_DataID",
                        column: x => x.DataID,
                        principalTable: "dataresultTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "modelTarget",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Outcome = table.Column<string>(nullable: true),
                    DataID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelTarget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_modelTarget_dataresultTable_DataID",
                        column: x => x.DataID,
                        principalTable: "dataresultTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "modelWell",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    wId = table.Column<string>(nullable: true),
                    Species = table.Column<string>(nullable: true),
                    Cq = table.Column<string>(nullable: true),
                    DataID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelWell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_modelWell_dataresultTable_DataID",
                        column: x => x.DataID,
                        principalTable: "dataresultTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_modelTag_DataID",
                table: "modelTag",
                column: "DataID");

            migrationBuilder.CreateIndex(
                name: "IX_modelTarget_DataID",
                table: "modelTarget",
                column: "DataID");

            migrationBuilder.CreateIndex(
                name: "IX_modelWell_DataID",
                table: "modelWell",
                column: "DataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "credentialsTable");

            migrationBuilder.DropTable(
                name: "instrumentsTable");

            migrationBuilder.DropTable(
                name: "modelTag");

            migrationBuilder.DropTable(
                name: "modelTarget");

            migrationBuilder.DropTable(
                name: "modelWell");

            migrationBuilder.DropTable(
                name: "rawindexTable");

            migrationBuilder.DropTable(
                name: "trackersTable");

            migrationBuilder.DropTable(
                name: "dataresultTable");
        }
    }
}
