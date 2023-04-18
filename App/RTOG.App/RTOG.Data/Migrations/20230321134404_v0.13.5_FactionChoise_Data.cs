using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v0135_FactionChoise_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FactionChoices",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "America" });

            migrationBuilder.InsertData(
                table: "FactionChoices",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "China" });

            migrationBuilder.InsertData(
                table: "FactionChoices",
                columns: new[] { "ID", "Name" },
                values: new object[] { 3, "Russia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FactionChoices",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FactionChoices",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FactionChoices",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
