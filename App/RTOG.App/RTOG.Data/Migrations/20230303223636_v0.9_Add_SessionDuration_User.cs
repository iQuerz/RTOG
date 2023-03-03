using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTOG.Data.Migrations
{
    public partial class v09_Add_SessionDuration_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Factions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SessionDuration",
                table: "Accounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.InsertData(
                table: "PlayerColors",
                columns: new[] { "ID", "Hex", "Name" },
                values: new object[] { 1, "#000", "Black" });

            migrationBuilder.InsertData(
                table: "PlayerColors",
                columns: new[] { "ID", "Hex", "Name" },
                values: new object[] { 2, "#f33", "Red" });

            migrationBuilder.InsertData(
                table: "PlayerColors",
                columns: new[] { "ID", "Hex", "Name" },
                values: new object[] { 3, "#3f3", "Green" });

            migrationBuilder.InsertData(
                table: "PlayerColors",
                columns: new[] { "ID", "Hex", "Name" },
                values: new object[] { 4, "#33f", "Blue" });

            migrationBuilder.InsertData(
                table: "PlayerColors",
                columns: new[] { "ID", "Hex", "Name" },
                values: new object[] { 5, "#ff3", "Yellow" });

            migrationBuilder.InsertData(
                table: "PlayerColors",
                columns: new[] { "ID", "Hex", "Name" },
                values: new object[] { 6, "#f3f", "Magenta" });

            migrationBuilder.InsertData(
                table: "PlayerColors",
                columns: new[] { "ID", "Hex", "Name" },
                values: new object[] { 7, "#3ff", "Cyan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerColors",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlayerColors",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlayerColors",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlayerColors",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlayerColors",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PlayerColors",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PlayerColors",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Factions");

            migrationBuilder.DropColumn(
                name: "SessionDuration",
                table: "Accounts");
        }
    }
}
