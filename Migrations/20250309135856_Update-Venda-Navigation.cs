using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuProjetoMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVendaNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vendas_idCliente",
                table: "Vendas",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_idProduto",
                table: "Vendas",
                column: "idProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_idCliente",
                table: "Vendas",
                column: "idCliente",
                principalTable: "Clientes",
                principalColumn: "idCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_idProduto",
                table: "Vendas",
                column: "idProduto",
                principalTable: "Produtos",
                principalColumn: "idProduto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_idCliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_idProduto",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_idCliente",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_idProduto",
                table: "Vendas");
        }
    }
}
