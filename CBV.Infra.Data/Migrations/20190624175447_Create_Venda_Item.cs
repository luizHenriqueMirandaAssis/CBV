using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CBV.Infra.Data.Migrations
{
    public partial class Create_Venda_Item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Venda",
              columns: table => new
              {
                  VendaId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                  ValorTotal = table.Column<decimal>(nullable: false),
                  CashbackTotal = table.Column<decimal>(nullable: false),
                  Data = table.Column<DateTime>(nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Venda", x => x.VendaId);
              });

            migrationBuilder.CreateTable(
                name: "ItemVenda",
                columns: table => new
                {
                    ItemVendaId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscoId = table.Column<int>(nullable: false),
                    VendaId = table.Column<int>(nullable: false),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    CashbackPercentual = table.Column<decimal>(nullable: false),
                    CashbackValor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenda", x => x.ItemVendaId);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Disco_DiscoId",
                        column: x => x.DiscoId,
                        principalTable: "Disco",
                        principalColumn: "DiscoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "VendaId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                       name: "ItemVenda");

            migrationBuilder.DropTable(
                name: "Venda");
        }
    }
}
