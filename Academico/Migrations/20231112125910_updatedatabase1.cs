using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academico.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoDisciplinas_Curso_CursoId",
                table: "CursoDisciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CursoDisciplinas",
                table: "CursoDisciplinas");

            migrationBuilder.DropIndex(
                name: "IX_CursoDisciplinas_CursoId",
                table: "CursoDisciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoDisciplina",
                table: "AlunoDisciplina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curso",
                table: "Curso");

            migrationBuilder.RenameTable(
                name: "Curso",
                newName: "Cursos");

            migrationBuilder.RenameColumn(
                name: "InstituicaoID",
                table: "Instituicoes",
                newName: "InstituicaoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Disciplinas",
                newName: "DisciplinaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departamentos",
                newName: "DepartamentoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cursos",
                newName: "CursoId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Instituicoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Instituicoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Disciplinas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Departamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CursoDisciplinaId",
                table: "CursoDisciplinas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursoDisciplinas",
                table: "CursoDisciplinas",
                columns: new[] { "CursoId", "DisciplinaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoDisciplina",
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "CursoId");

            migrationBuilder.CreateTable(
                name: "InstituicaoDepartamentos",
                columns: table => new
                {
                    InstituicaoId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    InstituicaoDepartamentoId = table.Column<int>(type: "int", nullable: true),
                    InstituicaoId1 = table.Column<long>(type: "bigint", nullable: true),
                    DepartamentoId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituicaoDepartamentos", x => new { x.InstituicaoId, x.DepartamentoId });
                    table.ForeignKey(
                        name: "FK_InstituicaoDepartamentos_Departamentos_DepartamentoId1",
                        column: x => x.DepartamentoId1,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId");
                    table.ForeignKey(
                        name: "FK_InstituicaoDepartamentos_Instituicoes_InstituicaoId1",
                        column: x => x.InstituicaoId1,
                        principalTable: "Instituicoes",
                        principalColumn: "InstituicaoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_AlunoId",
                table: "Disciplinas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplinas_DisciplinaId",
                table: "CursoDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituicaoDepartamentos_DepartamentoId1",
                table: "InstituicaoDepartamentos",
                column: "DepartamentoId1");

            migrationBuilder.CreateIndex(
                name: "IX_InstituicaoDepartamentos_InstituicaoId1",
                table: "InstituicaoDepartamentos",
                column: "InstituicaoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoDisciplinas_Cursos_CursoId",
                table: "CursoDisciplinas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Alunos_AlunoId",
                table: "Disciplinas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoDisciplinas_Cursos_CursoId",
                table: "CursoDisciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Alunos_AlunoId",
                table: "Disciplinas");

            migrationBuilder.DropTable(
                name: "InstituicaoDepartamentos");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_AlunoId",
                table: "Disciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CursoDisciplinas",
                table: "CursoDisciplinas");

            migrationBuilder.DropIndex(
                name: "IX_CursoDisciplinas_DisciplinaId",
                table: "CursoDisciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoDisciplina",
                table: "AlunoDisciplina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "CursoDisciplinaId",
                table: "CursoDisciplinas");

            migrationBuilder.RenameTable(
                name: "Cursos",
                newName: "Curso");

            migrationBuilder.RenameColumn(
                name: "InstituicaoId",
                table: "Instituicoes",
                newName: "InstituicaoID");

            migrationBuilder.RenameColumn(
                name: "DisciplinaId",
                table: "Disciplinas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Departamentos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "Curso",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Instituicoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Instituicoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Departamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursoDisciplinas",
                table: "CursoDisciplinas",
                columns: new[] { "DisciplinaId", "CursoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoDisciplina",
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "Semestre", "Ano" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curso",
                table: "Curso",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplinas_CursoId",
                table: "CursoDisciplinas",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoDisciplinas_Curso_CursoId",
                table: "CursoDisciplinas",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
