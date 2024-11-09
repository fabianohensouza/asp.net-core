using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saic.Migrations
{
    /// <inheritdoc />
    public partial class AddQtdCompts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QtdEqpmts",
                table: "Coops",
                newName: "QtdCompts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QtdCompts",
                table: "Coops",
                newName: "QtdEqpmts");
        }
    }
}
