using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AtualizandoEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desenvolvedores_LancamentoHora_LancamentoHorasId",
                table: "Desenvolvedores");

            migrationBuilder.DropIndex(
                name: "IX_Desenvolvedores_LancamentoHorasId",
                table: "Desenvolvedores");

            migrationBuilder.DropColumn(
                name: "LancamentoHorasId",
                table: "Desenvolvedores");

            migrationBuilder.DropColumn(
                name: "LancamentoId",
                table: "Desenvolvedores");

            migrationBuilder.AddColumn<int>(
                name: "DesenvolvedorId",
                table: "LancamentoHora",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "LancamentoHora",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Projetosid",
                table: "LancamentoHora",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome_Desenvolvedor",
                table: "Desenvolvedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Projeto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoHora_DesenvolvedorId",
                table: "LancamentoHora",
                column: "DesenvolvedorId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoHora_Projetosid",
                table: "LancamentoHora",
                column: "Projetosid");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoHora_Desenvolvedores_DesenvolvedorId",
                table: "LancamentoHora",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoHora_Projeto_Projetosid",
                table: "LancamentoHora",
                column: "Projetosid",
                principalTable: "Projeto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoHora_Desenvolvedores_DesenvolvedorId",
                table: "LancamentoHora");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoHora_Projeto_Projetosid",
                table: "LancamentoHora");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_LancamentoHora_DesenvolvedorId",
                table: "LancamentoHora");

            migrationBuilder.DropIndex(
                name: "IX_LancamentoHora_Projetosid",
                table: "LancamentoHora");

            migrationBuilder.DropColumn(
                name: "DesenvolvedorId",
                table: "LancamentoHora");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "LancamentoHora");

            migrationBuilder.DropColumn(
                name: "Projetosid",
                table: "LancamentoHora");

            migrationBuilder.DropColumn(
                name: "Nome_Desenvolvedor",
                table: "Desenvolvedores");

            migrationBuilder.AddColumn<int>(
                name: "LancamentoHorasId",
                table: "Desenvolvedores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LancamentoId",
                table: "Desenvolvedores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Desenvolvedores_LancamentoHorasId",
                table: "Desenvolvedores",
                column: "LancamentoHorasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desenvolvedores_LancamentoHora_LancamentoHorasId",
                table: "Desenvolvedores",
                column: "LancamentoHorasId",
                principalTable: "LancamentoHora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
