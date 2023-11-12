﻿// <auto-generated />
using Academico.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Academico.Migrations
{
    [DbContext(typeof(AcademicoContext))]
    partial class AcademicoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Academico.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlunoId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlunoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Academico.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int>("AlunoDisciplinaId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("AlunoDisciplinas");
                });

            modelBuilder.Entity("Academico.Models.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CursoId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CursoId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Academico.Models.CursoDisciplina", b =>
                {
                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int>("CursoDisciplinaId")
                        .HasColumnType("int");

                    b.HasKey("CursoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("CursoDisciplinas");
                });

            modelBuilder.Entity("Academico.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartamentoId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Academico.Models.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisciplinaId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DisciplinaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("Academico.Models.Instituicao", b =>
                {
                    b.Property<int>("InstituicaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstituicaoId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstituicaoId");

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("Academico.Models.InstituicaoDepartamento", b =>
                {
                    b.Property<int>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("InstituicaoDepartamentoId")
                        .HasColumnType("int");

                    b.HasKey("InstituicaoId", "DepartamentoId");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("InstituicaoDepartamentos");
                });

            modelBuilder.Entity("Academico.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("Academico.Models.Aluno", "Aluno")
                        .WithMany("AlunoDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Academico.Models.Disciplina", "Disciplina")
                        .WithMany("AlunoDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("Academico.Models.CursoDisciplina", b =>
                {
                    b.HasOne("Academico.Models.Curso", "Curso")
                        .WithMany("CursoDisciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Academico.Models.Disciplina", "Disciplina")
                        .WithMany("CursoDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("Academico.Models.InstituicaoDepartamento", b =>
                {
                    b.HasOne("Academico.Models.Departamento", "Departamento")
                        .WithMany("InstituicaoDepartamentos")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Academico.Models.Instituicao", "Instituicao")
                        .WithMany("InstituicaoDepartamentos")
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("Academico.Models.Aluno", b =>
                {
                    b.Navigation("AlunoDisciplinas");
                });

            modelBuilder.Entity("Academico.Models.Curso", b =>
                {
                    b.Navigation("CursoDisciplinas");
                });

            modelBuilder.Entity("Academico.Models.Departamento", b =>
                {
                    b.Navigation("InstituicaoDepartamentos");
                });

            modelBuilder.Entity("Academico.Models.Disciplina", b =>
                {
                    b.Navigation("AlunoDisciplinas");

                    b.Navigation("CursoDisciplinas");
                });

            modelBuilder.Entity("Academico.Models.Instituicao", b =>
                {
                    b.Navigation("InstituicaoDepartamentos");
                });
#pragma warning restore 612, 618
        }
    }
}