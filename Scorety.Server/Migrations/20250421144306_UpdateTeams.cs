using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scorety.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FoundedDate",
                table: "Teams",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Conference",
                table: "Teams",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Division",
                table: "Teams",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamType",
                table: "Teams",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conference",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Division",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamType",
                table: "Teams");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FoundedDate",
                table: "Teams",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
