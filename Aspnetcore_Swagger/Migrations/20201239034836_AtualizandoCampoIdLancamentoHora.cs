using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AtualizandoCampoIdLancamentoHora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoHora_Projeto_ProjetosId",
                table: "LancamentoHora");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "LancamentoHora");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetosId",
                table: "LancamentoHora",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoHora_Projeto_ProjetosId",
                table: "LancamentoHora",
                column: "ProjetosId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoHora_Projeto_ProjetosId",
                table: "LancamentoHora");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetosId",
                table: "LancamentoHora",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "LancamentoHora",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoHora_Projeto_ProjetosId",
                table: "LancamentoHora",
                column: "ProjetosId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
