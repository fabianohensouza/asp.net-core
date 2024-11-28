using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saic.Migrations
{
    /// <inheritdoc />
    public partial class AdjustServidorSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servidores",
                columns: table => new
                {
                    ServidorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServidorNome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ServidorModelo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ServidorCPU = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ServidorSerial = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ServidorVirtual = table.Column<bool>(type: "bit", nullable: false),
                    ServidorRAM = table.Column<int>(type: "int", nullable: true),
                    ServidorIP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ServidorIDrac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServidorAcesso = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ServidorGarantia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServidorObs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistOpID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnidadeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoopID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FabricanteID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servidores", x => x.ServidorID);
                    table.ForeignKey(
                        name: "FK_Servidores_Coops_ServidorID",
                        column: x => x.ServidorID,
                        principalTable: "Coops",
                        principalColumn: "CoopID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servidores_Fabricantes_FabricanteID",
                        column: x => x.FabricanteID,
                        principalTable: "Fabricantes",
                        principalColumn: "FabricanteID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servidores_SistOps_SistOpID",
                        column: x => x.SistOpID,
                        principalTable: "SistOps",
                        principalColumn: "SistOpID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servidores_Unidades_ServidorID",
                        column: x => x.ServidorID,
                        principalTable: "Unidades",
                        principalColumn: "UnidadeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servidores_FabricanteID",
                table: "Servidores",
                column: "FabricanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Servidores_SistOpID",
                table: "Servidores",
                column: "SistOpID");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servidores");            
        }
    }
}
