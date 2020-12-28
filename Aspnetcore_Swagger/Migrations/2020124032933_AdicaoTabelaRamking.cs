using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AdicaoTabelaRamking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoHora_Desenvolvedores_DesenvolvedorId",
                table: "LancamentoHora");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoHora_Projeto_ProjetosId",
                table: "LancamentoHora");

            migrationBuilder.CreateTable(
                name: "Rankings",
                columns: table => new
                {
                    DesenvolvedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorasTrabalhadasNaSemana = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rankings", x => x.DesenvolvedorId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoHora_Desenvolvedores_DesenvolvedorId",
                table: "LancamentoHora",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoHora_Projeto_ProjetosId",
                table: "LancamentoHora",
                column: "ProjetosId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoHora_Desenvolvedores_DesenvolvedorId",
                table: "LancamentoHora");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoHora_Projeto_ProjetosId",
                table: "LancamentoHora");

            migrationBuilder.DropTable(
                name: "Rankings");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoHora_Desenvolvedores_DesenvolvedorId",
                table: "LancamentoHora",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoHora_Projeto_ProjetosId",
                table: "LancamentoHora",
                column: "ProjetosId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
