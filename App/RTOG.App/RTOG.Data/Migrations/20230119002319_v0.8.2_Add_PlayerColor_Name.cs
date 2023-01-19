using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v082_Add_PlayerColor_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ColorHex",
                table: "PlayerColors",
                newName: "Hex");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PlayerColors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PlayerColors");

            migrationBuilder.RenameColumn(
                name: "Hex",
                table: "PlayerColors",
                newName: "ColorHex");
        }
    }
}
