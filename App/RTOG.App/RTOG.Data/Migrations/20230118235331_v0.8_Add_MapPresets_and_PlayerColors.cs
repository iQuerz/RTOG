using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v08_Add_MapPresets_and_PlayerColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EdgePresets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTileID = table.Column<int>(type: "INTEGER", nullable: false),
                    EndTileID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdgePresets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EdgePresets_Tiles_EndTileID",
                        column: x => x.EndTileID,
                        principalTable: "Tiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EdgePresets_Tiles_StartTileID",
                        column: x => x.StartTileID,
                        principalTable: "Tiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapPresets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapPresets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerColors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerColors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TilePresets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PositionY = table.Column<float>(type: "REAL", nullable: false),
                    PositionX = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TilePresets", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EdgePresets_EndTileID",
                table: "EdgePresets",
                column: "EndTileID");

            migrationBuilder.CreateIndex(
                name: "IX_EdgePresets_StartTileID",
                table: "EdgePresets",
                column: "StartTileID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EdgePresets");

            migrationBuilder.DropTable(
                name: "MapPresets");

            migrationBuilder.DropTable(
                name: "PlayerColors");

            migrationBuilder.DropTable(
                name: "TilePresets");
        }
    }
}
