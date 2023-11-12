using Academico.Models;
using Microsoft.EntityFrameworkCore;

namespace Academico.Data
{
    public class AcademicoContext : DbContext
    {
        public AcademicoContext(DbContextOptions<AcademicoContext> options) : base(options)
        {
        }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set;}
        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }
        public DbSet<CursoDisciplina>  CursoDisciplinas {  get; set; }
        public DbSet<InstituicaoDepartamento> InstituicaoDepartamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defina chaves primárias compostas para tabelas de relacionamento, se necessário
            modelBuilder.Entity<AlunoDisciplina>().HasKey(id => new { id.AlunoId, id.DisciplinaId });
            modelBuilder.Entity<CursoDisciplina>().HasKey(id => new { id.CursoId, id.DisciplinaId });
            modelBuilder.Entity<InstituicaoDepartamento>().HasKey(id => new { id.InstituicaoId, id.DepartamentoId });

            // Adicione outras configurações do modelo, se necessário

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Academico.Models.AlunoDisciplina>? AlunoDisciplina { get; set; }
    }
}
