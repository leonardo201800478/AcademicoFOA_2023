using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class AlunoDisciplina
    {
        [Key]
        public int AlunoDisciplinaId { get; set; }

        [ForeignKey("Aluno")]
        public int AlunoId { get; set; }
        [ForeignKey("Disciplina")]
        public int DisciplinaId { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}
