using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v012_Add_Color_to_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelectedColorID",
                table: "Accounts",
                type: "INTEGER",
                nullable: true,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_SelectedColorID",
                table: "Accounts",
                column: "SelectedColorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_PlayerColors_SelectedColorID",
                table: "Accounts",
                column: "SelectedColorID",
                principalTable: "PlayerColors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_PlayerColors_SelectedColorID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_SelectedColorID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "SelectedColorID",
                table: "Accounts");
        }
    }
}
