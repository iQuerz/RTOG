using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v0101_Removed_Player_AllUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Players_PlayerID",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_PlayerID",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "Units");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "Units",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_PlayerID",
                table: "Units",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Players_PlayerID",
                table: "Units",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID");
        }
    }
}
