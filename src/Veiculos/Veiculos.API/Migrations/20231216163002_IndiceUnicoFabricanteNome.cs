using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veiculos.API.Migrations
{
    public partial class IndiceUnicoFabricanteNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UK_Fabricante_Nome",
                table: "fabricante",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_Fabricante_Nome",
                table: "fabricante");
        }
    }
}
