using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v03_Add_Player_to_account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Accounts_PlayerAccountID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerAccountID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerAccountID",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "Accounts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PlayerID",
                table: "Accounts",
                column: "PlayerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Players_PlayerID",
                table: "Accounts",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Players_PlayerID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PlayerID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "PlayerAccountID",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerAccountID",
                table: "Players",
                column: "PlayerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Accounts_PlayerAccountID",
                table: "Players",
                column: "PlayerAccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
