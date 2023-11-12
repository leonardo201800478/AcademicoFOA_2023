using Academico.Models;
using Microsoft.EntityFrameworkCore;
namespace Academico.Data;

public class AcademicoContext : DbContext
{
    // Adicione um construtor que recebe as opções do DbContext
    public AcademicoContext(DbContextOptions<AcademicoContext> options) : base(options)
    {
    }

    // Adicione propriedades DbSet para cada uma das suas entidades
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Disciplina> Disciplinas { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Instituicao> Instituicoes { get; set; }

    // Adicione os DbSet para as tabelas de relacionamento
    public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }
    public DbSet<CursoDisciplina> CursoDisciplinas { get; set; }
    public DbSet<InstituicaoDepartamento> InstituicaoDepartamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Defina chaves primárias compostas para tabelas de relacionamento, se necessário
        modelBuilder.Entity<AlunoDisciplina>().HasKey(ad => new { ad.AlunoId, ad.DisciplinaId });
        modelBuilder.Entity<CursoDisciplina>().HasKey(cd => new { cd.CursoId, cd.DisciplinaId });
        modelBuilder.Entity<InstituicaoDepartamento>().HasKey(id => new { id.InstituicaoId, id.DepartamentoId });

        // Adicione outras configurações do modelo, se necessário

        base.OnModelCreating(modelBuilder);
    }
}
