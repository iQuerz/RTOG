using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v014_TurnOrder_SelectedFaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurnOrder",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelectedFactionID",
                table: "Accounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_SelectedFactionID",
                table: "Accounts",
                column: "SelectedFactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_FactionChoices_SelectedFactionID",
                table: "Accounts",
                column: "SelectedFactionID",
                principalTable: "FactionChoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_FactionChoices_SelectedFactionID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_SelectedFactionID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "TurnOrder",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SelectedFactionID",
                table: "Accounts");
        }
    }
}
