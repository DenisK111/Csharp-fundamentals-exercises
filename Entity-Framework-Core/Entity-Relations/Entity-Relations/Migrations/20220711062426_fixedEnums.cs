using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Relations.Migrations
{
    public partial class fixedEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionTime",
                table: "HomeworkSubmissions",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 11, 9, 24, 25, 805, DateTimeKind.Local).AddTicks(4007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionTime",
                table: "HomeworkSubmissions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 7, 11, 9, 24, 25, 805, DateTimeKind.Local).AddTicks(4007));
        }
    }
}
