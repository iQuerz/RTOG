using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v011_TilePreset_Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MapPresetID",
                table: "TilePresets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TilePresets_MapPresetID",
                table: "TilePresets",
                column: "MapPresetID");

            migrationBuilder.AddForeignKey(
                name: "FK_TilePresets_MapPresets_MapPresetID",
                table: "TilePresets",
                column: "MapPresetID",
                principalTable: "MapPresets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TilePresets_MapPresets_MapPresetID",
                table: "TilePresets");

            migrationBuilder.DropIndex(
                name: "IX_TilePresets_MapPresetID",
                table: "TilePresets");

            migrationBuilder.DropColumn(
                name: "MapPresetID",
                table: "TilePresets");
        }
    }
}
