using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v05_Add_Tiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Factions_FactionID",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Tile_Maps_MapID",
                table: "Tile");

            migrationBuilder.DropForeignKey(
                name: "FK_Tile_Players_OwnerID",
                table: "Tile");

            migrationBuilder.DropForeignKey(
                name: "FK_Tile_Tile_TileID",
                table: "Tile");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Factions_MyFactionID",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Players_MyPlayerID",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Tile_MyTileID",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Players_FactionID",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tile",
                table: "Tile");

            migrationBuilder.DropColumn(
                name: "FactionID",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Tile",
                newName: "Tiles");

            migrationBuilder.RenameColumn(
                name: "MyTileID",
                table: "Units",
                newName: "TileID");

            migrationBuilder.RenameColumn(
                name: "MyPlayerID",
                table: "Units",
                newName: "PlayerID");

            migrationBuilder.RenameColumn(
                name: "MyFactionID",
                table: "Units",
                newName: "FactionID");

            migrationBuilder.RenameIndex(
                name: "IX_Units_MyTileID",
                table: "Units",
                newName: "IX_Units_TileID");

            migrationBuilder.RenameIndex(
                name: "IX_Units_MyPlayerID",
                table: "Units",
                newName: "IX_Units_PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_Units_MyFactionID",
                table: "Units",
                newName: "IX_Units_FactionID");

            migrationBuilder.RenameIndex(
                name: "IX_Tile_TileID",
                table: "Tiles",
                newName: "IX_Tiles_TileID");

            migrationBuilder.RenameIndex(
                name: "IX_Tile_OwnerID",
                table: "Tiles",
                newName: "IX_Tiles_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Tile_MapID",
                table: "Tiles",
                newName: "IX_Tiles_MapID");

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "Factions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tiles",
                table: "Tiles",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_PlayerID",
                table: "Factions",
                column: "PlayerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factions_Players_PlayerID",
                table: "Factions",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Maps_MapID",
                table: "Tiles",
                column: "MapID",
                principalTable: "Maps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Players_OwnerID",
                table: "Tiles",
                column: "OwnerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Tiles_TileID",
                table: "Tiles",
                column: "TileID",
                principalTable: "Tiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_FactionID",
                table: "Units",
                column: "FactionID",
                principalTable: "Factions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Players_PlayerID",
                table: "Units",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Tiles_TileID",
                table: "Units",
                column: "TileID",
                principalTable: "Tiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factions_Players_PlayerID",
                table: "Factions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Maps_MapID",
                table: "Tiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Players_OwnerID",
                table: "Tiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Tiles_TileID",
                table: "Tiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Factions_FactionID",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Players_PlayerID",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Tiles_TileID",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Factions_PlayerID",
                table: "Factions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tiles",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "Factions");

            migrationBuilder.RenameTable(
                name: "Tiles",
                newName: "Tile");

            migrationBuilder.RenameColumn(
                name: "TileID",
                table: "Units",
                newName: "MyTileID");

            migrationBuilder.RenameColumn(
                name: "PlayerID",
                table: "Units",
                newName: "MyPlayerID");

            migrationBuilder.RenameColumn(
                name: "FactionID",
                table: "Units",
                newName: "MyFactionID");

            migrationBuilder.RenameIndex(
                name: "IX_Units_TileID",
                table: "Units",
                newName: "IX_Units_MyTileID");

            migrationBuilder.RenameIndex(
                name: "IX_Units_PlayerID",
                table: "Units",
                newName: "IX_Units_MyPlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_Units_FactionID",
                table: "Units",
                newName: "IX_Units_MyFactionID");

            migrationBuilder.RenameIndex(
                name: "IX_Tiles_TileID",
                table: "Tile",
                newName: "IX_Tile_TileID");

            migrationBuilder.RenameIndex(
                name: "IX_Tiles_OwnerID",
                table: "Tile",
                newName: "IX_Tile_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Tiles_MapID",
                table: "Tile",
                newName: "IX_Tile_MapID");

            migrationBuilder.AddColumn<int>(
                name: "FactionID",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tile",
                table: "Tile",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_FactionID",
                table: "Players",
                column: "FactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Factions_FactionID",
                table: "Players",
                column: "FactionID",
                principalTable: "Factions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tile_Maps_MapID",
                table: "Tile",
                column: "MapID",
                principalTable: "Maps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tile_Players_OwnerID",
                table: "Tile",
                column: "OwnerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tile_Tile_TileID",
                table: "Tile",
                column: "TileID",
                principalTable: "Tile",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_MyFactionID",
                table: "Units",
                column: "MyFactionID",
                principalTable: "Factions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Players_MyPlayerID",
                table: "Units",
                column: "MyPlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Tile_MyTileID",
                table: "Units",
                column: "MyTileID",
                principalTable: "Tile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
