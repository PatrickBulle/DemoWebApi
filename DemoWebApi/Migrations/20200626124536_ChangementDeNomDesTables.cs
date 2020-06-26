using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWebApi.Migrations
{
    public partial class ChangementDeNomDesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbBovins_DbRaces_RaceCodeRaceBovin",
                table: "DbBovins");

            migrationBuilder.DropForeignKey(
                name: "FK_DbBovins_DbCheptels_CheptelCodePays_CheptelNumero",
                table: "DbBovins");

            migrationBuilder.DropForeignKey(
                name: "FK_DbCheptels_DbDetenteurs_nuchep",
                table: "DbCheptels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbRaces",
                table: "DbRaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbDetenteurs",
                table: "DbDetenteurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbCheptels",
                table: "DbCheptels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbBovins",
                table: "DbBovins");

            migrationBuilder.RenameTable(
                name: "DbRaces",
                newName: "race");

            migrationBuilder.RenameTable(
                name: "DbDetenteurs",
                newName: "detenteur");

            migrationBuilder.RenameTable(
                name: "DbCheptels",
                newName: "cheptel");

            migrationBuilder.RenameTable(
                name: "DbBovins",
                newName: "bovin");

            migrationBuilder.RenameIndex(
                name: "IX_DbCheptels_nuchep",
                table: "cheptel",
                newName: "IX_cheptel_nuchep");

            migrationBuilder.RenameIndex(
                name: "IX_DbBovins_CheptelCodePays_CheptelNumero",
                table: "bovin",
                newName: "IX_bovin_CheptelCodePays_CheptelNumero");

            migrationBuilder.RenameIndex(
                name: "IX_DbBovins_RaceCodeRaceBovin",
                table: "bovin",
                newName: "IX_bovin_RaceCodeRaceBovin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_race",
                table: "race",
                column: "corabo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detenteur",
                table: "detenteur",
                column: "nudet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cheptel",
                table: "cheptel",
                columns: new[] { "copach", "nuchep" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_bovin",
                table: "bovin",
                columns: new[] { "copaip", "nunati" });

            migrationBuilder.AddForeignKey(
                name: "FK_bovin_race_RaceCodeRaceBovin",
                table: "bovin",
                column: "RaceCodeRaceBovin",
                principalTable: "race",
                principalColumn: "corabo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bovin_cheptel_CheptelCodePays_CheptelNumero",
                table: "bovin",
                columns: new[] { "CheptelCodePays", "CheptelNumero" },
                principalTable: "cheptel",
                principalColumns: new[] { "copach", "nuchep" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cheptel_detenteur_nuchep",
                table: "cheptel",
                column: "nuchep",
                principalTable: "detenteur",
                principalColumn: "nudet",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bovin_race_RaceCodeRaceBovin",
                table: "bovin");

            migrationBuilder.DropForeignKey(
                name: "FK_bovin_cheptel_CheptelCodePays_CheptelNumero",
                table: "bovin");

            migrationBuilder.DropForeignKey(
                name: "FK_cheptel_detenteur_nuchep",
                table: "cheptel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_race",
                table: "race");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detenteur",
                table: "detenteur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cheptel",
                table: "cheptel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bovin",
                table: "bovin");

            migrationBuilder.RenameTable(
                name: "race",
                newName: "DbRaces");

            migrationBuilder.RenameTable(
                name: "detenteur",
                newName: "DbDetenteurs");

            migrationBuilder.RenameTable(
                name: "cheptel",
                newName: "DbCheptels");

            migrationBuilder.RenameTable(
                name: "bovin",
                newName: "DbBovins");

            migrationBuilder.RenameIndex(
                name: "IX_cheptel_nuchep",
                table: "DbCheptels",
                newName: "IX_DbCheptels_nuchep");

            migrationBuilder.RenameIndex(
                name: "IX_bovin_CheptelCodePays_CheptelNumero",
                table: "DbBovins",
                newName: "IX_DbBovins_CheptelCodePays_CheptelNumero");

            migrationBuilder.RenameIndex(
                name: "IX_bovin_RaceCodeRaceBovin",
                table: "DbBovins",
                newName: "IX_DbBovins_RaceCodeRaceBovin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbRaces",
                table: "DbRaces",
                column: "corabo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbDetenteurs",
                table: "DbDetenteurs",
                column: "nudet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbCheptels",
                table: "DbCheptels",
                columns: new[] { "copach", "nuchep" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbBovins",
                table: "DbBovins",
                columns: new[] { "copaip", "nunati" });

            migrationBuilder.AddForeignKey(
                name: "FK_DbBovins_DbRaces_RaceCodeRaceBovin",
                table: "DbBovins",
                column: "RaceCodeRaceBovin",
                principalTable: "DbRaces",
                principalColumn: "corabo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbBovins_DbCheptels_CheptelCodePays_CheptelNumero",
                table: "DbBovins",
                columns: new[] { "CheptelCodePays", "CheptelNumero" },
                principalTable: "DbCheptels",
                principalColumns: new[] { "copach", "nuchep" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbCheptels_DbDetenteurs_nuchep",
                table: "DbCheptels",
                column: "nuchep",
                principalTable: "DbDetenteurs",
                principalColumn: "nudet",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
