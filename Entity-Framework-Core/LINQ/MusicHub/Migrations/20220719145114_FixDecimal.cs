using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicHub.Migrations
{
    public partial class FixDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "decimal(18,4",
                table: "Songs",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "decimal(18,4)",
                table: "Performers",
                newName: "NetWorth");

            migrationBuilder.RenameColumn(
                name: "decimal(18,4)",
                table: "Albums",
                newName: "Price");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Songs",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 51, 13, 467, DateTimeKind.Local).AddTicks(8034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 38, 12, 477, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Songs",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetWorth",
                table: "Performers",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Albums",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Songs",
                newName: "decimal(18,4");

            migrationBuilder.RenameColumn(
                name: "NetWorth",
                table: "Performers",
                newName: "decimal(18,4)");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Albums",
                newName: "decimal(18,4)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Songs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 38, 12, 477, DateTimeKind.Local).AddTicks(5039),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 51, 13, 467, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.AlterColumn<decimal>(
                name: "decimal(18,4",
                table: "Songs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "decimal(18,4)",
                table: "Performers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "decimal(18,4)",
                table: "Albums",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}
