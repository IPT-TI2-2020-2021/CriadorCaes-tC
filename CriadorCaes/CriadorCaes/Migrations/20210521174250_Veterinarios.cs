using Microsoft.EntityFrameworkCore.Migrations;

namespace CriadorCaes.Migrations
{
    public partial class Veterinarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Honorario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaesVeterinarios",
                columns: table => new
                {
                    ListaDeCaesTratadosId = table.Column<int>(type: "int", nullable: false),
                    ListaVetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaesVeterinarios", x => new { x.ListaDeCaesTratadosId, x.ListaVetsId });
                    table.ForeignKey(
                        name: "FK_CaesVeterinarios_Caes_ListaDeCaesTratadosId",
                        column: x => x.ListaDeCaesTratadosId,
                        principalTable: "Caes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaesVeterinarios_Veterinarios_ListaVetsId",
                        column: x => x.ListaVetsId,
                        principalTable: "Veterinarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaesVeterinarios_ListaVetsId",
                table: "CaesVeterinarios",
                column: "ListaVetsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaesVeterinarios");

            migrationBuilder.DropTable(
                name: "Veterinarios");
        }
    }
}
