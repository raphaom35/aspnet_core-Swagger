using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AtualizandoBasesCorrecao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancamentoHora");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LancamentoHora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesenvolvedorId = table.Column<int>(type: "int", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    ProjetosId = table.Column<int>(type: "int", nullable: true),
                    data_fim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_inicio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoHora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentoHora_Desenvolvedores_DesenvolvedorId",
                        column: x => x.DesenvolvedorId,
                        principalTable: "Desenvolvedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LancamentoHora_Projeto_ProjetosId",
                        column: x => x.ProjetosId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoHora_DesenvolvedorId",
                table: "LancamentoHora",
                column: "DesenvolvedorId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoHora_ProjetosId",
                table: "LancamentoHora",
                column: "ProjetosId");
        }
    }
}
