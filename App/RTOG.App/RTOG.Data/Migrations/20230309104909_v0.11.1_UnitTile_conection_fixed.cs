using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v0111_UnitTile_conection_fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Tiles_TileID",
                table: "Units");

            migrationBuilder.AlterColumn<int>(
                name: "TileID",
                table: "Units",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Tiles_TileID",
                table: "Units",
                column: "TileID",
                principalTable: "Tiles",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Tiles_TileID",
                table: "Units");

            migrationBuilder.AlterColumn<int>(
                name: "TileID",
                table: "Units",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Tiles_TileID",
                table: "Units",
                column: "TileID",
                principalTable: "Tiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
