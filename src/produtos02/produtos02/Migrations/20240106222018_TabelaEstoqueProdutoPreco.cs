using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace produtos02.Migrations
{
    public partial class TabelaEstoqueProdutoPreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(16,3)", nullable: false),
                    CustoMedio = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Estoque_produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoPreco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoPreco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoPreco_produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPreco_ProdutoId",
                table: "ProdutoPreco",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "ProdutoPreco");
        }
    }
}
