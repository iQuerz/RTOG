using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v07_Changed_PlayerID_in_Game_instead_of_accountID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Games_OngoingGameID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Factions_FactionID",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_OngoingGameID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "GoldPerTurn",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "OngoingGameID",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "FactionID",
                table: "Units",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_FactionID",
                table: "Units",
                column: "FactionID",
                principalTable: "Factions",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Factions_FactionID",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "FactionID",
                table: "Units",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoldPerTurn",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OngoingGameID",
                table: "Accounts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OngoingGameID",
                table: "Accounts",
                column: "OngoingGameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Games_OngoingGameID",
                table: "Accounts",
                column: "OngoingGameID",
                principalTable: "Games",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_FactionID",
                table: "Units",
                column: "FactionID",
                principalTable: "Factions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
