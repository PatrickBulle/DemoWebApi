using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbDetenteurs",
                columns: table => new
                {
                    nudet = table.Column<string>(maxLength: 12, nullable: false),
                    dcre = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    dmaj = table.Column<DateTime>(type: "TimeStamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    cosu = table.Column<char>(nullable: false, defaultValue: '0'),
                    Nom = table.Column<string>(maxLength: 20, nullable: false),
                    Prenom = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbDetenteurs", x => x.nudet);
                });

            migrationBuilder.CreateTable(
                name: "DbRaces",
                columns: table => new
                {
                    corabo = table.Column<string>(maxLength: 2, nullable: false),
                    dcre = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    dmaj = table.Column<DateTime>(type: "TimeStamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    cosu = table.Column<char>(nullable: false, defaultValue: '0'),
                    libelo = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbRaces", x => x.corabo);
                });

            migrationBuilder.CreateTable(
                name: "DbCheptels",
                columns: table => new
                {
                    copach = table.Column<string>(maxLength: 2, nullable: false),
                    nuchep = table.Column<string>(maxLength: 10, nullable: false),
                    dcre = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    dmaj = table.Column<DateTime>(type: "TimeStamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    cosu = table.Column<char>(nullable: false, defaultValue: '0'),
                    sicivi = table.Column<string>(maxLength: 20, nullable: false),
                    noraso = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbCheptels", x => new { x.copach, x.nuchep });
                    table.ForeignKey(
                        name: "FK_DbCheptels_DbDetenteurs_nuchep",
                        column: x => x.nuchep,
                        principalTable: "DbDetenteurs",
                        principalColumn: "nudet",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbBovins",
                columns: table => new
                {
                    copaip = table.Column<string>(maxLength: 2, nullable: false),
                    nunati = table.Column<string>(maxLength: 12, nullable: false),
                    dcre = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    dmaj = table.Column<DateTime>(type: "TimeStamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    cosu = table.Column<char>(nullable: false, defaultValue: '0'),
                    nobovi = table.Column<string>(maxLength: 10, nullable: true),
                    sexbov = table.Column<int>(maxLength: 1, nullable: false),
                    RaceCodeRaceBovin = table.Column<string>(nullable: true),
                    CheptelCodePays = table.Column<string>(nullable: true),
                    CheptelNumero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbBovins", x => new { x.copaip, x.nunati });
                    table.ForeignKey(
                        name: "FK_DbBovins_DbRaces_RaceCodeRaceBovin",
                        column: x => x.RaceCodeRaceBovin,
                        principalTable: "DbRaces",
                        principalColumn: "corabo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbBovins_DbCheptels_CheptelCodePays_CheptelNumero",
                        columns: x => new { x.CheptelCodePays, x.CheptelNumero },
                        principalTable: "DbCheptels",
                        principalColumns: new[] { "copach", "nuchep" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbBovins_RaceCodeRaceBovin",
                table: "DbBovins",
                column: "RaceCodeRaceBovin");

            migrationBuilder.CreateIndex(
                name: "IX_DbBovins_CheptelCodePays_CheptelNumero",
                table: "DbBovins",
                columns: new[] { "CheptelCodePays", "CheptelNumero" });

            migrationBuilder.CreateIndex(
                name: "IX_DbCheptels_nuchep",
                table: "DbCheptels",
                column: "nuchep");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbBovins");

            migrationBuilder.DropTable(
                name: "DbRaces");

            migrationBuilder.DropTable(
                name: "DbCheptels");

            migrationBuilder.DropTable(
                name: "DbDetenteurs");
        }
    }
}
