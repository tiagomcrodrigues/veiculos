using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veiculos.API.Migrations
{
    public partial class ChaveEstrangeiraFabricante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "veiculo");

            migrationBuilder.AddColumn<Guid>(
                name: "FabricanteId",
                table: "veiculo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_FabricanteId",
                table: "veiculo",
                column: "FabricanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_veiculo_fabricante_FabricanteId",
                table: "veiculo",
                column: "FabricanteId",
                principalTable: "fabricante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_veiculo_fabricante_FabricanteId",
                table: "veiculo");

            migrationBuilder.DropIndex(
                name: "IX_veiculo_FabricanteId",
                table: "veiculo");

            migrationBuilder.DropColumn(
                name: "FabricanteId",
                table: "veiculo");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "veiculo",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);
        }
    }
}
