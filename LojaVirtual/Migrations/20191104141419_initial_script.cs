using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Migrations
{
    public partial class initial_script : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfiguracaoLojas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PercentualLucro = table.Column<decimal>(nullable: false),
                    CustoDespesa = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoLojas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    PrecoVenda = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false),
                    Custo = table.Column<decimal>(nullable: false),
                    CaminhoImagem = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracaoLojas");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
