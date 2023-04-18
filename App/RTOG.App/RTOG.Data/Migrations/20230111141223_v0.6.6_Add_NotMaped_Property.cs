using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v066_Add_NotMaped_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Tiles_TileID",
                table: "Tiles");

            migrationBuilder.DropIndex(
                name: "IX_Tiles_TileID",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "TileID",
                table: "Tiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TileID",
                table: "Tiles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tiles_TileID",
                table: "Tiles",
                column: "TileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Tiles_TileID",
                table: "Tiles",
                column: "TileID",
                principalTable: "Tiles",
                principalColumn: "ID");
        }
    }
}
