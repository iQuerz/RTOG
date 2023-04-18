using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v00_Create_Account_Lobby_and_OngoingGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    IsGuest = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastActive = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SessionID = table.Column<string>(type: "TEXT", nullable: false),
                    LobbyID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lobbies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    HostID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lobbies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lobbies_Accounts_HostID",
                        column: x => x.HostID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LobbyID",
                table: "Accounts",
                column: "LobbyID");

            migrationBuilder.CreateIndex(
                name: "IX_Lobbies_HostID",
                table: "Lobbies",
                column: "HostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Lobbies_LobbyID",
                table: "Accounts",
                column: "LobbyID",
                principalTable: "Lobbies",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Lobbies_LobbyID",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Lobbies");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
