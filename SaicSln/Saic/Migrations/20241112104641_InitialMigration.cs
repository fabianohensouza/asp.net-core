using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saic.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RespCoops",
                columns: table => new
                {
                    RespID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RespNome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespCoops", x => x.RespID);
                });

            migrationBuilder.CreateTable(
                name: "Coops",
                columns: table => new
                {
                    CoopID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoopNumero = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CoopNome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CoopCidade = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Adesao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QtdCompts = table.Column<int>(type: "int", nullable: true),
                    RespID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coops", x => x.CoopID);
                    table.ForeignKey(
                        name: "FK_Coops_RespCoops_RespID",
                        column: x => x.RespID,
                        principalTable: "RespCoops",
                        principalColumn: "RespID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coops_RespID",
                table: "Coops",
                column: "RespID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coops");

            migrationBuilder.DropTable(
                name: "RespCoops");
        }
    }
}
