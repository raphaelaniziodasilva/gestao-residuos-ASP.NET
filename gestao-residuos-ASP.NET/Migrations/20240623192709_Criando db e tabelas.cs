using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestao_residuos_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class Criandodbetabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_contato",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    Rua = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_contato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_lixo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Capacidade = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_lixo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_coleta_agendada",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataColeta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Observacoes = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    ContatoId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    LixoId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_coleta_agendada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_coleta_agendada_tbl_contato_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "tbl_contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_coleta_agendada_tbl_lixo_LixoId",
                        column: x => x.LixoId,
                        principalTable: "tbl_lixo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_coleta_agendada_ContatoId",
                table: "tbl_coleta_agendada",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_coleta_agendada_LixoId",
                table: "tbl_coleta_agendada",
                column: "LixoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_contato_Email",
                table: "tbl_contato",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_coleta_agendada");

            migrationBuilder.DropTable(
                name: "tbl_contato");

            migrationBuilder.DropTable(
                name: "tbl_lixo");
        }
    }
}
