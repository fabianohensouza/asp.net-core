using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saic.Migrations
{
    /// <inheritdoc />
    public partial class IncreaseSistOpNomeLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SistOpNome",
                table: "SistOps",
                type: "nvarchar(50)", // Adjust size as needed
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SistOpNome",
                table: "SistOps",
                type: "nvarchar(20)", // Revert to old size
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");
        }

    }
}
