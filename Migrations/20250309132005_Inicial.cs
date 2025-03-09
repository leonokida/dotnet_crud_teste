using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuProjetoMVC.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nmCliente = table.Column<string>(type: "TEXT", nullable: false),
                    cidade = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    idProduto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dscProduto = table.Column<string>(type: "TEXT", nullable: false),
                    vlrUnitario = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.idProduto);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    idVenda = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    idProduto = table.Column<int>(type: "INTEGER", nullable: false),
                    qtdVenda = table.Column<int>(type: "INTEGER", nullable: false),
                    vlrUnitarioVenda = table.Column<float>(type: "REAL", nullable: false),
                    dthVenda = table.Column<DateTime>(type: "TEXT", nullable: false),
                    vlrTotalVenda = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.idVenda);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
