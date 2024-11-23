using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saic.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinkProvedor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LinkIP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LinkObs = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UnidadeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoLinkID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    VlanRangeIP = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
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
                name: "IX_Links_TipoLinkID",
                table: "Links",
                column: "TipoLinkID");

            migrationBuilder.CreateIndex(
                name: "IX_Links_UnidadeID",
                table: "Links",
                column: "UnidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Vlans_UnidadeID",
                table: "Vlans",
                column: "UnidadeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Vlans");
        }
    }
}
