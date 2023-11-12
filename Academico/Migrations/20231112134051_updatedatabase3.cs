using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academico.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Alunos_AlunoId",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_AlunoId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Disciplinas");

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Cursos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DisciplinaId",
                table: "Alunos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId1",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_DisciplinaId",
                table: "Cursos",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_DisciplinaId1",
                table: "Alunos",
                column: "DisciplinaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Disciplinas_DisciplinaId1",
                table: "Alunos",
                column: "DisciplinaId1",
                principalTable: "Disciplinas",
                principalColumn: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Disciplinas_DisciplinaId",
                table: "Cursos",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "DisciplinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Disciplinas_DisciplinaId1",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Disciplinas_DisciplinaId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_DisciplinaId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_DisciplinaId1",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "DisciplinaId1",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Disciplinas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_AlunoId",
                table: "Disciplinas",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Alunos_AlunoId",
                table: "Disciplinas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId");
        }
    }
}
