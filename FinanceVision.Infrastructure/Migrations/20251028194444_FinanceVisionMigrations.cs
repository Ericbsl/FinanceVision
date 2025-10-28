using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceVision.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinanceVisionMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeBanco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoConta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnpjCpfTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaFinanceira",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaFinanceira", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermiteParcelamento = table.Column<bool>(type: "bit", nullable: false),
                    DataCriado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEmpresa = table.Column<long>(type: "bigint", nullable: false),
                    IdBanco = table.Column<long>(type: "bigint", nullable: true),
                    IdCategoria = table.Column<long>(type: "bigint", nullable: true),
                    IdFormaPgto = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Banco_IdBanco",
                        column: x => x.IdBanco,
                        principalTable: "Banco",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pagamento_CategoriaFinanceira_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "CategoriaFinanceira",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pagamento_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_FormaPagamento_IdFormaPgto",
                        column: x => x.IdFormaPgto,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PagamentoParcela",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroParcela = table.Column<int>(type: "int", nullable: false),
                    ValorParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Juros = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Multa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodBarra = table.Column<int>(type: "int", nullable: true),
                    IdPagamento = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoParcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentoParcela_Pagamento_IdPagamento",
                        column: x => x.IdPagamento,
                        principalTable: "Pagamento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_IdBanco",
                table: "Pagamento",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_IdCategoria",
                table: "Pagamento",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_IdEmpresa",
                table: "Pagamento",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_IdFormaPgto",
                table: "Pagamento",
                column: "IdFormaPgto");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoParcela_IdPagamento",
                table: "PagamentoParcela",
                column: "IdPagamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagamentoParcela");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "CategoriaFinanceira");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "FormaPagamento");
        }
    }
}
