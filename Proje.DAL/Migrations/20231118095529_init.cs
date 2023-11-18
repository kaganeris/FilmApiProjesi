using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dil = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sure = table.Column<double>(type: "float", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilinmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilinmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Oyuncular",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soyad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cinsiyet = table.Column<int>(type: "int", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ulke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilinmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oyuncular", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FilmlerKategoriler",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmlerKategoriler", x => new { x.KategoriID, x.FilmID });
                    table.ForeignKey(
                        name: "FK_FilmlerKategoriler_Filmler_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Filmler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmlerKategoriler_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmlerOyuncular",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    OyuncuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmlerOyuncular", x => new { x.OyuncuID, x.FilmID });
                    table.ForeignKey(
                        name: "FK_FilmlerOyuncular_Filmler_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Filmler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmlerOyuncular_Oyuncular_OyuncuID",
                        column: x => x.OyuncuID,
                        principalTable: "Oyuncular",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmlerKategoriler_FilmID",
                table: "FilmlerKategoriler",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmlerOyuncular_FilmID",
                table: "FilmlerOyuncular",
                column: "FilmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmlerKategoriler");

            migrationBuilder.DropTable(
                name: "FilmlerOyuncular");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Filmler");

            migrationBuilder.DropTable(
                name: "Oyuncular");
        }
    }
}
