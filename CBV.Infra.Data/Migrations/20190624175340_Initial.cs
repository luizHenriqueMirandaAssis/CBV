using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBV.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaSemana",
                columns: table => new
                {
                    DiaSemanaId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaSemana", x => x.DiaSemanaId);
                });

            migrationBuilder.CreateTable(
                    name: "Genero",
                    columns: table => new
                    {
                        GeneroId = table.Column<int>(nullable: false),
                        Nome = table.Column<string>(maxLength: 10, nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Genero", x => x.GeneroId);
                    });


            migrationBuilder.CreateTable(
                name: "Disco",
                columns: table => new
                {
                    DiscoId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GeneroId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    Artistas = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disco", x => x.DiscoId);
                    table.ForeignKey(
                        name: "FK_Disco_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                    name: "Cashback",
                    columns: table => new
                    {
                        CashbackId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        GeneroId = table.Column<int>(nullable: false),
                        DiaSemanaId = table.Column<int>(nullable: false),
                        Percentual = table.Column<decimal>(nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Cashback", x => x.CashbackId);
                        table.ForeignKey(
                            name: "FK_Cashback_DiaSemana_DiaSemanaId",
                            column: x => x.DiaSemanaId,
                            principalTable: "DiaSemana",
                            principalColumn: "DiaSemanaId",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_Cashback_Genero_GeneroId",
                            column: x => x.GeneroId,
                            principalTable: "Genero",
                            principalColumn: "GeneroId",
                            onDelete: ReferentialAction.Cascade);
                    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Cashback");

            migrationBuilder.DropTable(
                name: "Disco");

            migrationBuilder.DropTable(
                name: "DiaSemana");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
