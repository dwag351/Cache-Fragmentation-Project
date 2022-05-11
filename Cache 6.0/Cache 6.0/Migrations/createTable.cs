using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class createTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Filename = table.Column<string>(type: "TEXT", nullable: false),
                    TotalChunks = table.Column<string>(type: "INTEGER", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    ChunksLoaded = table.Column<string>(type: "INTEGER", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Filename);
                });
            migrationBuilder.CreateTable(
                name: "EventContent",
                columns: table => new
                {
                    ID = table.Column<string>(type: "INTEGER", nullable: false),
                    Event = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventContent", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Content");
            migrationBuilder.DropTable(
                name: "EventContent");
        }
    }
}
