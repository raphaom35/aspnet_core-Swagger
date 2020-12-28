using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AtualizandoBasesCorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoHora_Projeto_Projetosid",
                table: "LancamentoHora");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Projeto",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Projetosid",
                table: "LancamentoHora",
                newName: "ProjetosId");

            migrationBuilder.RenameIndex(
                name: "IX_LancamentoHora_Projetosid",
                table: "LancamentoHora",
                newName: "IX_LancamentoHora_ProjetosId");

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
                name: "FK_LancamentoHora_Projeto_ProjetosId",
                table: "LancamentoHora");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projeto",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProjetosId",
                table: "LancamentoHora",
                newName: "Projetosid");

            migrationBuilder.RenameIndex(
                name: "IX_LancamentoHora_ProjetosId",
                table: "LancamentoHora",
                newName: "IX_LancamentoHora_Projetosid");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoHora_Projeto_Projetosid",
                table: "LancamentoHora",
                column: "Projetosid",
                principalTable: "Projeto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
