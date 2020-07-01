using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detenteur",
                columns: table => new
                {
                    nudet = table.Column<string>(maxLength: 12, nullable: false),
                    dcre = table.Column<DateTime>(type: "Date", nullable: false),
                    dmaj = table.Column<DateTime>(type: "TimeStamp", nullable: false),
                    cosu = table.Column<string>(maxLength: 1, nullable: false),
                    Nom = table.Column<string>(maxLength: 20, nullable: false),
                    Prenom = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detenteur", x => x.nudet);
                });

            migrationBuilder.CreateTable(
                name: "race",
                columns: table => new
                {
                    corabo = table.Column<string>(maxLength: 2, nullable: false),
                    dcre = table.Column<DateTime>(type: "Date", nullable: false),
                    dmaj = table.Column<DateTime>(type: "TimeStamp", nullable: false),
                    cosu = table.Column<string>(maxLength: 1, nullable: false),
                    libelo = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_race", x => x.corabo);
                });

            migrationBuilder.CreateTable(
                name: "cheptel",
                columns: table => new
                {
                    copach = table.Column<string>(maxLength: 2, nullable: false),
                    nuchep = table.Column<string>(maxLength: 10, nullable: false),
                    dcre = table.Column<DateTime>(type: "Date", nullable: false),
                    dmaj = table.Column<DateTime>(type: "TimeStamp", nullable: false),
                    cosu = table.Column<string>(maxLength: 1, nullable: false),
                    sicivi = table.Column<string>(maxLength: 20, nullable: false),
                    noraso = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cheptel", x => new { x.copach, x.nuchep });
                    table.ForeignKey(
                        name: "FK_cheptel_detenteur_nuchep",
                        column: x => x.nuchep,
                        principalTable: "detenteur",
                        principalColumn: "nudet",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bovin",
                columns: table => new
                {
                    copaip = table.Column<string>(maxLength: 2, nullable: false),
                    nunati = table.Column<string>(maxLength: 12, nullable: false),
                    dcre = table.Column<DateTime>(type: "Date", nullable: false),
                    dmaj = table.Column<DateTime>(type: "TimeStamp", nullable: false),
                    cosu = table.Column<string>(maxLength: 1, nullable: false),
                    nobovi = table.Column<string>(maxLength: 10, nullable: true),
                    sexbov = table.Column<int>(maxLength: 1, nullable: false),
                    RaceCodeRaceBovin = table.Column<string>(nullable: true),
                    CheptelCodePays = table.Column<string>(nullable: true),
                    CheptelNumero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bovin", x => new { x.copaip, x.nunati });
                    table.ForeignKey(
                        name: "FK_bovin_race_RaceCodeRaceBovin",
                        column: x => x.RaceCodeRaceBovin,
                        principalTable: "race",
                        principalColumn: "corabo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bovin_cheptel_CheptelCodePays_CheptelNumero",
                        columns: x => new { x.CheptelCodePays, x.CheptelNumero },
                        principalTable: "cheptel",
                        principalColumns: new[] { "copach", "nuchep" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bovin_RaceCodeRaceBovin",
                table: "bovin",
                column: "RaceCodeRaceBovin");

            migrationBuilder.CreateIndex(
                name: "IX_bovin_CheptelCodePays_CheptelNumero",
                table: "bovin",
                columns: new[] { "CheptelCodePays", "CheptelNumero" });

            migrationBuilder.CreateIndex(
                name: "IX_cheptel_nuchep",
                table: "cheptel",
                column: "nuchep");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bovin");

            migrationBuilder.DropTable(
                name: "race");

            migrationBuilder.DropTable(
                name: "cheptel");

            migrationBuilder.DropTable(
                name: "detenteur");
        }
    }
}
