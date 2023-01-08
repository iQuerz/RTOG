using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v01_Add_OngoingGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OngoingGameID",
                table: "Accounts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Games_OngoingGameID",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_OngoingGameID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "OngoingGameID",
                table: "Accounts");
        }
    }
}
