using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v02_Add_All_GameModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MapID",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TurnCounter",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerAccountID = table.Column<int>(type: "INTEGER", nullable: false),
                    GameID = table.Column<int>(type: "INTEGER", nullable: false),
                    FactionID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TotalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    GoldPerTurn = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Players_Accounts_PlayerAccountID",
                        column: x => x.PlayerAccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Factions_FactionID",
                        column: x => x.FactionID,
                        principalTable: "Factions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerID = table.Column<int>(type: "INTEGER", nullable: false),
                    MapID = table.Column<int>(type: "INTEGER", nullable: false),
                    Gold = table.Column<int>(type: "INTEGER", nullable: false),
                    PositionY = table.Column<float>(type: "REAL", nullable: false),
                    PositionX = table.Column<float>(type: "REAL", nullable: false),
                    TileID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tile_Maps_MapID",
                        column: x => x.MapID,
                        principalTable: "Maps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tile_Players_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tile_Tile_TileID",
                        column: x => x.TileID,
                        principalTable: "Tile",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Movement = table.Column<int>(type: "INTEGER", nullable: false),
                    MyTileID = table.Column<int>(type: "INTEGER", nullable: false),
                    MyFactionID = table.Column<int>(type: "INTEGER", nullable: false),
                    MyPlayerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Units_Factions_MyFactionID",
                        column: x => x.MyFactionID,
                        principalTable: "Factions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Units_Players_MyPlayerID",
                        column: x => x.MyPlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Units_Tile_MyTileID",
                        column: x => x.MyTileID,
                        principalTable: "Tile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitUpgrades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UnitID = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitUpgrades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UnitUpgrades_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_MapID",
                table: "Games",
                column: "MapID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_FactionID",
                table: "Players",
                column: "FactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameID",
                table: "Players",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerAccountID",
                table: "Players",
                column: "PlayerAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Tile_MapID",
                table: "Tile",
                column: "MapID");

            migrationBuilder.CreateIndex(
                name: "IX_Tile_OwnerID",
                table: "Tile",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tile_TileID",
                table: "Tile",
                column: "TileID");

            migrationBuilder.CreateIndex(
                name: "IX_Units_MyFactionID",
                table: "Units",
                column: "MyFactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Units_MyPlayerID",
                table: "Units",
                column: "MyPlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Units_MyTileID",
                table: "Units",
                column: "MyTileID");

            migrationBuilder.CreateIndex(
                name: "IX_UnitUpgrades_UnitID",
                table: "UnitUpgrades",
                column: "UnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Maps_MapID",
                table: "Games",
                column: "MapID",
                principalTable: "Maps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Maps_MapID",
                table: "Games");

            migrationBuilder.DropTable(
                name: "UnitUpgrades");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Tile");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropIndex(
                name: "IX_Games_MapID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MapID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TurnCounter",
                table: "Games");
        }
    }
}
