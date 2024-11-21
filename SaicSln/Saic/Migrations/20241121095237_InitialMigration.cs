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
                name: "Equipes",
                columns: table => new
                {
                    EquipeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipeNome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EquipeDescrição = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.EquipeID);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    FabricanteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FabricanteTipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FabricanteNome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.FabricanteID);
                });

            migrationBuilder.CreateTable(
                name: "TipoLinks",
                columns: table => new
                {
                    TipoLinkID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoLinkNome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLinks", x => x.TipoLinkID);
                });

            migrationBuilder.CreateTable(
                name: "RespCoops",
                columns: table => new
                {
                    RespID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RespNome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EquipeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespCoops", x => x.RespID);
                    table.ForeignKey(
                        name: "FK_RespCoops_Equipes_EquipeID",
                        column: x => x.EquipeID,
                        principalTable: "Equipes",
                        principalColumn: "EquipeID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    UnidadeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnidadeNumero = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    UnidadeNome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    UnidadeObs = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CoopID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.UnidadeID);
                    table.ForeignKey(
                        name: "FK_Unidades_Coops_CoopID",
                        column: x => x.CoopID,
                        principalTable: "Coops",
                        principalColumn: "CoopID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Firewalls",
                columns: table => new
                {
                    FirewallID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirewallModelo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FirewallSerial = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FirewallBackup = table.Column<bool>(type: "bit", maxLength: 40, nullable: false),
                    FirewallObs = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CoopID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnidadeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FabricanteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firewalls", x => x.FirewallID);
                    table.ForeignKey(
                        name: "FK_Firewalls_Coops_CoopID",
                        column: x => x.CoopID,
                        principalTable: "Coops",
                        principalColumn: "CoopID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Firewalls_Fabricantes_FabricanteID",
                        column: x => x.FabricanteID,
                        principalTable: "Fabricantes",
                        principalColumn: "FabricanteID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Firewalls_Unidades_UnidadeID",
                        column: x => x.UnidadeID,
                        principalTable: "Unidades",
                        principalColumn: "UnidadeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinkProvedor = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    LinkIP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UnidadeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TipoLinkID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkID);
                    table.ForeignKey(
                        name: "FK_Links_TipoLinks_TipoLinkID",
                        column: x => x.TipoLinkID,
                        principalTable: "TipoLinks",
                        principalColumn: "TipoLinkID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Links_Unidades_UnidadeID",
                        column: x => x.UnidadeID,
                        principalTable: "Unidades",
                        principalColumn: "UnidadeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vlans",
                columns: table => new
                {
                    VlanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VlanTag = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VlanNome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    VlanIP = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    VlanObs = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UnidadeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vlans", x => x.VlanID);
                    table.ForeignKey(
                        name: "FK_Vlans_Unidades_UnidadeID",
                        column: x => x.UnidadeID,
                        principalTable: "Unidades",
                        principalColumn: "UnidadeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coops_RespID",
                table: "Coops",
                column: "RespID");

            migrationBuilder.CreateIndex(
                name: "IX_Firewalls_CoopID",
                table: "Firewalls",
                column: "CoopID");

            migrationBuilder.CreateIndex(
                name: "IX_Firewalls_FabricanteID",
                table: "Firewalls",
                column: "FabricanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Firewalls_UnidadeID",
                table: "Firewalls",
                column: "UnidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Links_TipoLinkID",
                table: "Links",
                column: "TipoLinkID");

            migrationBuilder.CreateIndex(
                name: "IX_Links_UnidadeID",
                table: "Links",
                column: "UnidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_RespCoops_EquipeID",
                table: "RespCoops",
                column: "EquipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_CoopID",
                table: "Unidades",
                column: "CoopID");

            migrationBuilder.CreateIndex(
                name: "IX_Vlans_UnidadeID",
                table: "Vlans",
                column: "UnidadeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firewalls");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Vlans");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "TipoLinks");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Coops");

            migrationBuilder.DropTable(
                name: "RespCoops");

            migrationBuilder.DropTable(
                name: "Equipes");
        }
    }
}
