using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Aluno
    {
        public int? AlunoId { get; set; }
        [Required]
        [DisplayName("Matrícula")]
        public string? Matricula { get; set; }
        [Required]
        [DisplayName("Aluno")]
        public string? Nome { get; set; }
        [DisplayName("Disciplina")]
        public long DisciplinaId { get; set; }
        public Disciplina? Disciplina { get; set; }
        public ICollection<AlunoDisciplina>? AlunoDisciplinas { get; set; }
    }
}
