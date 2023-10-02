using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Polikinlikler",
                columns: table => new
                {
                    PolikinlikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolikinlikAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Polikinlikler", x => x.PolikinlikId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Randevu",
                columns: table => new
                {
                    RandevuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hasta = table.Column<int>(type: "int", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Randevu", x => x.RandevuId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Saatler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Saatler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Doktorlar",
                columns: table => new
                {
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorTc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolikinlikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Doktorlar", x => x.DoktorId);
                    table.ForeignKey(
                        name: "FK_tbl_Doktorlar_tbl_Polikinlikler_PolikinlikId",
                        column: x => x.PolikinlikId,
                        principalTable: "tbl_Polikinlikler",
                        principalColumn: "PolikinlikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Hastalar",
                columns: table => new
                {
                    HastaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaTc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Hastalar", x => x.HastaId);
                    table.ForeignKey(
                        name: "FK_tbl_Hastalar_tbl_Doktorlar_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "tbl_Doktorlar",
                        principalColumn: "DoktorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Doktorlar_PolikinlikId",
                table: "tbl_Doktorlar",
                column: "PolikinlikId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Hastalar_DoktorId",
                table: "tbl_Hastalar",
                column: "DoktorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Hastalar");

            migrationBuilder.DropTable(
                name: "tbl_Randevu");

            migrationBuilder.DropTable(
                name: "tbl_Saatler");

            migrationBuilder.DropTable(
                name: "tbl_Doktorlar");

            migrationBuilder.DropTable(
                name: "tbl_Polikinlikler");
        }
    }
}
