using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PEDIDO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CLIENTE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    PERCENTUALDESCONTO = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ITEMPEDIDO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PEDIDOID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PRODUTO = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    PRECOUNITARIO = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEMPEDIDO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ITEMPEDIDO_PEDIDO_PEDIDOID",
                        column: x => x.PEDIDOID,
                        principalTable: "PEDIDO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITEMPEDIDO_PEDIDOID",
                table: "ITEMPEDIDO",
                column: "PEDIDOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITEMPEDIDO");

            migrationBuilder.DropTable(
                name: "PEDIDO");
        }
    }
}
