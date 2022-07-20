using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicHub.Migrations
{
    public partial class FixIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Producers_ProducerId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Songs",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 57, 49, 333, DateTimeKind.Local).AddTicks(2172),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 51, 13, 467, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Songs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Albums",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Producers_ProducerId",
                table: "Albums",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Producers_ProducerId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Songs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 19, 17, 51, 13, 467, DateTimeKind.Local).AddTicks(8034),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 7, 19, 17, 57, 49, 333, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Songs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Albums",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Producers_ProducerId",
                table: "Albums",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
