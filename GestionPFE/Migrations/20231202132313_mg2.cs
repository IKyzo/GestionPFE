using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPFE.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaiss = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Societe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lib = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PFE",
                columns: table => new
                {
                    PFEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateF = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncadrantID = table.Column<int>(type: "int", nullable: false),
                    SocieteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFE", x => x.PFEID);
                    table.ForeignKey(
                        name: "FK_PFE_Enseignant_EncadrantID",
                        column: x => x.EncadrantID,
                        principalTable: "Enseignant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PFE_Societe_SocieteID",
                        column: x => x.SocieteID,
                        principalTable: "Societe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PFE_Etudiant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PFEID = table.Column<int>(type: "int", nullable: false),
                    EtudiantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFE_Etudiant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PFE_Etudiant_Etudiant_EtudiantID",
                        column: x => x.EtudiantID,
                        principalTable: "Etudiant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PFE_Etudiant_PFE_PFEID",
                        column: x => x.PFEID,
                        principalTable: "PFE",
                        principalColumn: "PFEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soutenance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Heure = table.Column<TimeSpan>(type: "time", nullable: false),
                    PFEID = table.Column<int>(type: "int", nullable: false),
                    PresidentID = table.Column<int>(type: "int", nullable: false),
                    RapporteurID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soutenance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Soutenance_Enseignant_PresidentID",
                        column: x => x.PresidentID,
                        principalTable: "Enseignant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soutenance_Enseignant_RapporteurID",
                        column: x => x.RapporteurID,
                        principalTable: "Enseignant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soutenance_PFE_PFEID",
                        column: x => x.PFEID,
                        principalTable: "PFE",
                        principalColumn: "PFEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PFE_EncadrantID",
                table: "PFE",
                column: "EncadrantID");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_SocieteID",
                table: "PFE",
                column: "SocieteID");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_Etudiant_EtudiantID",
                table: "PFE_Etudiant",
                column: "EtudiantID");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_Etudiant_PFEID",
                table: "PFE_Etudiant",
                column: "PFEID");

            migrationBuilder.CreateIndex(
                name: "IX_Soutenance_PFEID",
                table: "Soutenance",
                column: "PFEID");

            migrationBuilder.CreateIndex(
                name: "IX_Soutenance_PresidentID",
                table: "Soutenance",
                column: "PresidentID");

            migrationBuilder.CreateIndex(
                name: "IX_Soutenance_RapporteurID",
                table: "Soutenance",
                column: "RapporteurID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PFE_Etudiant");

            migrationBuilder.DropTable(
                name: "Soutenance");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.DropTable(
                name: "PFE");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Societe");
        }
    }
}
