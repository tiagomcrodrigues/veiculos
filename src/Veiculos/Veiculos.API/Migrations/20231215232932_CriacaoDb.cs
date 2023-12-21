using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veiculos.API.Migrations
{
    public partial class CriacaoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnoModelo = table.Column<short>(type: "smallint", nullable: false),
                    AnoFabricacao = table.Column<short>(type: "smallint", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Cor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Placa = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    Tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "veiculo");
        }
    }
}
