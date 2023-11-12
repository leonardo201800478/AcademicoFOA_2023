using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class CursoDisciplina
    {
        [Key]
        public int CursoDisciplinaId { get; set; }

        [ForeignKey("Curso")]
        public int CursoId { get; set; }
        [ForeignKey("Disciplina")]
        public int DisciplinaId { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}
