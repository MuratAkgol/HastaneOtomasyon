using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class mgRecete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "tbl_Recete",
                columns: table => new
                {
                    ReceteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceteIcerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Recete", x => x.ReceteId);
                    table.ForeignKey(
                        name: "FK_tbl_Recete_tbl_Hastalar_HastaId",
                        column: x => x.HastaId,
                        principalTable: "tbl_Hastalar",
                        principalColumn: "HastaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Recete_HastaId",
                table: "tbl_Recete",
                column: "HastaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Recete");

            migrationBuilder.DropColumn(
                name: "DoktorSifre",
                table: "tbl_Doktorlar");
        }
    }
}
